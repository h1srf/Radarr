FROM lscr.io/linuxserver/radarr:develop

# Remove the default Sonarr app
RUN rm -rf /app/radarr

# Copy the custom-built Sonarr files
COPY ./_artifacts/linux-musl-x64/net6.0/Radarr /app/radarr/bin
