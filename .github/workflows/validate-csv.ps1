
param (
    [string]$startDirectory = "."
)

if (-Not (Test-Path $startDirectory)) {
    Write-Error "Directory does not exist: $startDirectory"
    exit 1
}

$csvFiles = Get-ChildItem -Path $startDirectory -Filter *.csv -Recurse

if ($csvFiles.Count -eq 0) {
    Write-Output "No CSV files found in directory: $startDirectory"
    exit 0
}

foreach ($csvFile in $csvFiles) {
    Write-Output "Validating CSV file: $($csvFile.FullName)"
    
    try {

        $csvContent = Import-Csv -Path $csvFile.FullName
        Write-Output "CSV file $($csvFile.FullName) is valid."
    } catch {
        Write-Error "Error validating CSV file $($csvFile.FullName): $_"
        exit 1
    }
}

Write-Output "All CSV files validated successfully."
