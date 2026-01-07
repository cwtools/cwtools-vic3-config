desc=$(echo "$1" | head -2 | tail -1)
scopes=$(echo "$1" | grep -oP '\*\*Supported Scopes\*\*:\s*\K[a-z_, ]*' | xargs | sed 's/,//g' | sed 's/none/any/g')
target=$(echo "$1" | grep -oP '\*\*Supported Targets\*\*:\s*\K[a-z_, ]*' | xargs | sed 's/,//g' | sed 's/none/any/g')
list=$(echo "$1" | grep -oP '\#\# any_\K[a-z_]*' | xargs)

echo "$desc"
echo "$scopes"
echo "$target"
echo "$list"

echo "" >> ../config/lists.cwt
echo "### $desc" >> ../config/lists.cwt
echo "## scopes = { $scopes }" >> ../config/lists.cwt
echo "## push_scope = $target" >> ../config/lists.cwt
echo "alias[effect:every_$list] = single_alias_right[effect_every_list_clause]" >> ../config/lists.cwt
echo "### $desc" >> ../config/lists.cwt
echo "## scopes = { $scopes }" >> ../config/lists.cwt
echo "## push_scope = $target" >> ../config/lists.cwt
echo "alias[effect:random_$list] = single_alias_right[effect_random_list_clause]" >> ../config/lists.cwt
echo "### $desc" >> ../config/lists.cwt
echo "## scopes = { $scopes }" >> ../config/lists.cwt
echo "## push_scope = $target" >> ../config/lists.cwt
echo "alias[effect:ordered_$list] = single_alias_right[effect_ordered_list_clause]" >> ../config/lists.cwt
echo "### $desc" >> ../config/lists.cwt
echo "## scopes = { $scopes }" >> ../config/lists.cwt
echo "## push_scope = $target" >> ../config/lists.cwt
echo "alias[arithmetic_operation:every_$list] = single_alias_right[formula_every_list_clause]" >> ../config/lists.cwt
echo "### $desc" >> ../config/lists.cwt
echo "## scopes = { $scopes }" >> ../config/lists.cwt
echo "## push_scope = $target" >> ../config/lists.cwt
echo "alias[arithmetic_operation:random_$list] = single_alias_right[formula_random_list_clause]" >> ../config/lists.cwt
echo "### $desc" >> ../config/lists.cwt
echo "## scopes = { $scopes }" >> ../config/lists.cwt
echo "## push_scope = $target" >> ../config/lists.cwt
echo "alias[arithmetic_operation:ordered_$list] = single_alias_right[formula_ordered_list_clause]" >> ../config/lists.cwt
echo "### $desc" >> ../config/lists.cwt
echo "## scopes = { $scopes }" >> ../config/lists.cwt
echo "## push_scope = $target" >> ../config/lists.cwt
echo "alias[trigger:any_$list] = single_alias_right[trigger_any_list_clause]" >> ../config/lists.cwt