# Read the JSON file
$json = Get-Content -Path 'products.json' | ConvertFrom-Json

# Open the output file
$outputFile = New-Item -Path 'output.sql' -ItemType File -Force

foreach ($item in $json) {
    # Construct the SQL insert statement
    $columns = ($item.PSObject.Properties.Name -join ', ')
    $values = ($item.PSObject.Properties.Value | ForEach-Object { "'$($_.ToString().Replace("'", "''"))'" }) -join ', '
    $sql = "INSERT INTO Products ($columns) VALUES ($values);`n"

    # Write the SQL statement to the output file
    Add-Content -Path $outputFile.FullName -Value $sql
}