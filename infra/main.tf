terraform {
  backend "s3" {}
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = ">= 5.59"
    }
  }

  required_version = ">= 1.9.2"
} 

provider "aws" {
  region = "ap-southeast-2"
}

resource "aws_s3_bucket" "lambda_bucket" {
  bucket        = "${lower(var.app_name)}-lambda-bucket"
  force_destroy = true
}

module "api_lambda_function" {
  source = "./modules/lambda_function"
  bucket_id = aws_s3_bucket.lambda_bucket.id
  publish_dir = "${path.module}/../../../src/CommentToEmail/bin/Release/net8.0/linux-x64/publish"
  function_name = "CommentToEmailApi"
  handler = "CommentToEmail::CommentToEmail.Function::FunctionHandler"
}
