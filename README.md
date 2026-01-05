cwtools-vic3-config
.cwt config files for Victoria 3

# Usage
## VSCode (CWTools)
To use these:
1. Clone this repository to a filepath, e.g. D:\Git\cwtools-vic3-config. (or copy the contents of the zip you can download)
2. Open VS Code, and go to File, Preferences, Settings
   2.a. To make the changes only apply to this folder (not all folders on your computer), change the tab at the top to "workspace settings"
3. Set "cwtools.rules_version" to "manual"
4. Set "cwtools.rules_folder" to the path above. e.g. D:\Git\cwtools-vic3-config
5. Re-open VS Code.
   Once you make changes to the rules, you can press "Ctrl-shift-p" and select "Reload window" to easily restart the extension.
## IntelliJ (Paradox Language Support)
1. Open IntelliJ [settings](docs/settings.png) and go to the **Paradox Language Support** [config settings](docs/settings-location.png)
2. Enable [remote config groups](docs/enable-remote-config.png) and click the blue *configure* text
3. [Set the remote URL](docs/set-remote-location.png) of this repository for Victoria 3

# CWT Documentation
See https://github.com/tboby/cwtools/wiki/.cwt-config-file-guidance for guidance on the file format

# Contributing
If you'd like to contribute, press the pen icon on any file,
then press "Create a new branch for this commit and start a pull request".
You can then make further changes as a "pull request".
When done, mention it in the pull request and your changes will be included.
