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
                bat 'dotnet test'
            }
        }

        stage('Code Quality') {
            steps {
                echo 'SonarQube here'
            }
        }

        stage('Security') {
            steps {
                bat 'docker build -t restaurant-app .'
            }
        }

        stage('Deploy') {
            steps {
                bat 'docker run -d -p 5000:80 restaurant-app'
            }
        }

        stage('Release') {
            steps {
                echo 'Release done'
            }
        }

        stage('Monitoring') {
            steps {
                bat 'curl http://localhost:5000/health'
            }
        }
    }
}
