#!/usr/bin/env bash
set -e

# Optional: Set specific version/branch
export FRAMEWORK=net6.0
export RID=linux-musl-x64

# Build and package Sonarr for linux-musl
./build.sh --backend --frontend --packages --runtime $RID --framework $FRAMEWORK

# Mark binaries as executable
chmod +x "_artifacts/linux-musl-x64/$FRAMEWORK/Radarr/Radarr" || echo "No radarr found, skipping"

# If you bundle ffprobe, mark it executable too
chmod +x "_artifacts/linux-musl-x64/$FRAMEWORK/Radarr/ffprobe" || echo "No ffprobe found, skipping"
