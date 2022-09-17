#!bin/bash

cd "/home/abhishek/Programs/Hackathons/CoPHackathon/TheLastManStanding-Problem1/backend/SpaceAllocationTool"

MIGRATION_NAME=$1

if [ -z $MIGRATION_NAME ]
then
    echo "Usage: ./migrate.sh MIGRATION_NAME"
    exit
fi

echo "Creating migration: $MIGRATION_NAME"
dotnet ef migrations add "${MIGRATION_NAME}"

echo "Updating database"
dotnet ef database update

cd -
