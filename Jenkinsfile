node {
  def app

  stage('Fetch repository') {
    deleteDir()
    checkout scm
  }

  stage('Create build environment') {
    app = docker.build("ankh-morpork/mono")
  }

  stage('Build project') {
    app.inside {
      withEnv(["HOME=${ pwd() }"]) {
        sh 'nuget restore ./Mic.sln'
        sh "mdtool build --target:Build '--configuration:Release|x86' --project:Mic"
      }
      sh 'ln -s Mic/bin/Release/ MicRelease'
      sh 'zip -r Mic.zip MicRelease'
      archiveArtifacts artifacts: 'Mic.zip'
    }
  }
}
