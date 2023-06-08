docker login -u majumi -p uaimrzadzi

docker stop mechanicsdataservice

docker pull majumi/mechanicsdataservice:dataservice

docker run --name carsdataservice -p 5001:5001 -it majumi/mechanicsdataservice:dataservice

pause

docker stop mechanicsdataservice

docker rm mechanicsdataservice

pause