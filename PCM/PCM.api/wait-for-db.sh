#!/bin/bash
set -e

echo "=> wait-for-db: checking database availability"

# defaults
HOST="pcmdb"
PORT="1433"

# try parse ConnectionStrings__DefaultConnection if provided
CONN="${ConnectionStrings__DefaultConnection:-}"
if [ -n "$CONN" ]; then
  HOSTPORT=$(echo "$CONN" | sed -n 's/.*tcp:\([^;,]*\),\([0-9]*\).*/\1:\2/p; t; s/.*Server=\([^;,]*\),\([0-9]*\).*/\1:\2/p; t;')
  if [ -n "$HOSTPORT" ]; then
    HOST=$(echo "$HOSTPORT" | cut -d: -f1)
    PORT=$(echo "$HOSTPORT" | cut -d: -f2)
  fi
fi

MAX_TRIES=30
SLEEP=2
count=0

echo "=> wait-for-db: target $HOST:$PORT"
while ! bash -c ">/dev/tcp/$HOST/$PORT" 2>/dev/null; do
  count=$((count+1))
  echo "=> wait-for-db: attempt $count/$MAX_TRIES - $HOST:$PORT not available yet"
  if [ $count -ge $MAX_TRIES ]; then
    echo "=> wait-for-db: timeout waiting for $HOST:$PORT"
    break
  fi
  sleep $SLEEP
done

echo "=> wait-for-db: starting app"
exec dotnet PCM.dll
