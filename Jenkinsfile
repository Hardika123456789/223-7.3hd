pipeline {
    agent any

    stages {

        stage('Build') {
            steps {
                bat 'dotnet restore RestaurantApp.csproj'
                bat 'dotnet build RestaurantApp.csproj --configuration Release'
            }
        }

        stage('Test') {
            steps {
                echo 'Test stage (basic)'
            }
        }

        stage('Code Quality') {
            steps {
                echo 'SonarQube analysis'
            }
        }

        stage('Security') {
            steps {
                bat 'docker build -t restaurant-app .'
            }
        }

        stage('Deploy') {
            steps {
                bat 'docker rm -f restaurant-app-container || exit 0'
                bat 'docker run -d -p 5000:80 --name restaurant-app-container restaurant-app'
            }
        }

        stage('Release') {
            steps {
                echo 'Release done'
            }
        }

        stage('Monitoring') {
            steps {
                bat 'timeout /t 10'
                bat 'curl http://localhost:5000/health'
            }
        }
    }
}
