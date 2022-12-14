open System.Text
#r "nuget: CWTools"
#r @"C:\Users\Thomas\git\cwtools/CWTools/bin/Debug/netstandard2.0/CWTools.dll"

open System

open System.IO
open System.Security.Cryptography

open CWTools.Parser
open FParsec
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

// let triggers, effects = DocsParser.parseDocsFilesRes @"C:\Users\Thomas\git\cwtools\CWToolsTests\testfiles\validationtests\trigger_docs_2.1.0.txt"
let links = JominiParser.parseLinksFilesRes @"script-docs/event_targets.log"

// let tinner =
//             """{
// 	alias_name[effect] = alias_match_left[effect]
// }
// """
// let tout =
//     triggers |> List.map (fun t ->
//                         let scopes = t.scopes |> List.map (fun s -> s.ToString()) |> String.concat " "
//                         let scopes = if scopes = "" then "" else "## scopes = { " + scopes + " }\n"
//                         let any = t.name.StartsWith("any_")
//                         let rhs = if any then tinner else "replace_me"
//                         sprintf "###%s\n%salias[trigger:%s] = %s\n\r" t.desc scopes t.name rhs)
//                 |> String.concat("")

// let einner =
//             """{
//     ## cardinality = 0..1
// 	limit = {
// 		alias_name[trigger] = alias_match_left[trigger]
// 	}
// 	alias_name[effect] = alias_match_left[effect]
// }
// """
// let eout =
//     effects |> List.map (fun t ->
//                         let scopes = t.scopes |> List.map (fun s -> s.ToString()) |> String.concat " "
//                         let scopes = if scopes = "" then "" else "## scopes = { " + scopes + " }\n"
//                         let every = t.name.StartsWith("every_") || t.name.StartsWith("random_")
//                         let rhs = if every then einner else "replace_me"
//                         sprintf "###%s\n%salias[effect:%s] = %s\n\r" t.desc scopes t.name rhs)
//                 |> String.concat("")

// File.WriteAllText("triggers.cwt", tout)
// File.WriteAllText("effects.cwt", eout)

let createLink (n,(d : string),r,w,i,(o : string list option),g) =
    match r with
    | Some _ ->
        let input =
            match i with
            | None -> None
            | Some [x] ->
                Some ("input_scopes = " + x)
            | Some xs ->
                Some ("input_scopes = { " + ( String.concat " " (xs |> List.map (fun x -> x.Trim().Replace (" ", "_")))) + " }")
        let output =
            match o with
            | None -> None
            | Some oi -> Some ("output_scope = " + (oi |> List.head))
        let start = Some (n + " = {\n\t" + "desc = \"" + d + "\"")
        let fromData = g |> Option.map (fun _ -> "from_data = yes")
        let dataSource = g |> Option.map (fun _ -> ( "data_source = <" + n + ">"))
        let prefix =
            match g with
            | None -> None
            | Some _ -> Some (sprintf "prefix = %s:" n)
        ([start; fromData; dataSource; prefix; input; output]
        |> List.choose id
        |> String.concat ("\n\t")) + "\n}"
    | None ->
        let input =
            match i with
            | None -> None
            | Some [x] ->
                Some ("input_scopes = " + x)
            | Some xs ->
                Some ("input_scopes = { " + ( String.concat " " (xs |> List.map (fun x -> x.Trim().Replace (" ", "_")))) + " }")
        let output =
            match o with
            | None -> None
            | Some oi -> Some ("output_scope = " + (oi |> List.head))
        let start = Some (n + " = {\n\t" + "desc = \"" + d + "\"")
        let fromData = g |> Option.map (fun _ -> "from_data = yes")
        let dataSource = g |> Option.map (fun _ -> ( "data_source = <" + n + ">"))
        // let prefix =
        //     match g with
        //     | None -> None
        //     | Some _ -> Some (sprintf "prefix = %s:" n)
        ([start; fromData; dataSource; input; output;]
        |> List.choose id
        |> String.concat ("\n\t")) + "\n}"

let linksText = links |> List.map createLink
File.WriteAllLines("new-links.cwt", linksText)
