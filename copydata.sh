OUTPUT="src/data"

mkdir $OUTPUT
cd $OUTPUT

cp "/Library/Application Support/com.apple.idleassetsd/Customer/entries.json" entries.json
plistutil -f json -i "/Library/Application Support/com.apple.idleassetsd/Customer/TVIdleScreenStrings.bundle/en.lproj/Localizable.nocache.strings" -o en.json
plistutil -f json -i "/Library/Application Support/com.apple.idleassetsd/Customer/TVIdleScreenStrings.bundle/zh_CN.lproj/Localizable.nocache.strings" -o zh_CN.json
