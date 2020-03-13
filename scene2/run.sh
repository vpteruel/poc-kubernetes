#!/bin/bash

echo "###############"
echo "### RESTORE ###"
echo "###############"

dotnet restore lambda3-api/ &&
cd lambda3-request/ &&
npm install &&
cd ..

echo "###############"
echo "#### BUILD ####"
echo "###############"

dotnet build lambda3-api/

echo "###############"
echo "##### RUN #####"
echo "###############"

dotnet run --project lambda3-api/ &&
node lambda3-request/app.js
