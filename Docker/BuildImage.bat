docker login -u majumi -p uaimrzadzi

docker rmi majumi/mechanicsdataservice:dataservice

docker build -f ../majumi.CarService.MechanicsDataService.Rest/Dockerfile.prod -t majumi/mechanicsdataservice:dataservice ..

docker logout

pause