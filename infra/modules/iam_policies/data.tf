data "aws_caller_identity" "current" {

}

data "aws_region" "current" {

}

data "aws_iam_policy_document" "cloudwatch_put_metrics" {
  statement {
    actions   = ["cloudwatch:PutMetricData"]
    resources = ["*"]
  }
}
