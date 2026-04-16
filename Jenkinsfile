pipeline {
    agent any

    environment {
        IMAGE_NAME = "restaurant-app"
        CONTAINER_NAME = "restaurant-app-container"
    }

    stages {

        stage('Build') {
            steps {
                bat 'dotnet clean RestaurantApp_HD.sln'
                bat 'dotnet restore RestaurantApp_HD.sln'
                bat 'dotnet build RestaurantApp_HD.sln --configuration Release'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet clean RestaurantApp.Tests/RestaurantApp.Tests.csproj'
                bat 'dotnet restore RestaurantApp.Tests/RestaurantApp.Tests.csproj'
                bat 'dotnet test RestaurantApp.Tests/RestaurantApp.Tests.csproj --no-build'
            }
        }

        stage('Code Quality') {
            steps {
                bat 'dotnet tool install -g dotnet-format || exit 0'
                bat 'dotnet format --verify-no-changes || exit 0'
            }
        }

        stage('Security') {
            steps {
                bat 'docker build -t %IMAGE_NAME% .'
                bat 'docker run --rm aquasec/trivy image %IMAGE_NAME% || exit 0'
            }
        }

        stage('Deploy') {
            steps {
                bat 'docker rm -f %CONTAINER_NAME% || exit 0'
                bat 'docker run -d -p 5000:80 --name %CONTAINER_NAME% %IMAGE_NAME%'
            }
        }

        stage('Release') {
            steps {
                bat 'docker tag %IMAGE_NAME% %IMAGE_NAME%:latest'
            }
        }

        stage('Monitoring') {
            steps {
                bat 'ping 127.0.0.1 -n 10 > nul'
                bat 'curl http://localhost:5000/health'
                bat 'docker logs %CONTAINER_NAME%'
            }
        }
    }
}