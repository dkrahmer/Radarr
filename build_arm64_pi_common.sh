#!/usr/bin/env bash
set -e

echo "Building Radarr.Common and Radarr.Http for Raspberry Pi (ARM64)..."

cd src/NzbDrone.Common
dotnet build -c Release -r linux-arm64
cd ../Radarr.Http
dotnet build -c Release -r linux-arm64
cd ../..

echo ""
echo "Build complete!"
echo "Output location: $(pwd)/_output/net6.0/linux-arm64/publish/Radarr.Common.dll"
echo "Output location: $(pwd)/_output/net6.0/linux-arm64/publish/Radarr.Http.dll"