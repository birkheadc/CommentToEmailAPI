# Comment To Email API

A simple API that accepts comments from anonymous users and emails them to the admin. Mostly useful for feedback forms etc.

## Deployment

The project is configured to automatically deploy to AWS Lambda when pushes are made to the `main` branch. There is no development / staging environment due to the simplicity of the project.

### Applying TF changes locally

Github actions are in place to update infrastructure when pushing to `main`. Github holds repository secrets needed to access the S3 backend. In order to sync TF to this backend locally, these environment variables must be provided. Do so by exporting `AWS_ACCESS_KEY_ID` and `AWS_SECRET_ACCESS_KEY` into the terminal before performing terraform commands. Most of the time, terraform updates should be performed by simply pushing to the relevant branch. 

`AWS_ACCESS_KEY_ID=<your key> AWS_SECRET_ACCESS_KEY=<your secret> terraform init -backend-config=backend.conf`

To add the secrets on Github, go to the repository settings, click on "Secrets and Variables > Actions" under "Security", and add the repository secrets.