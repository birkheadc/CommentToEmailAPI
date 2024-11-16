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

data "aws_iam_policy_document" "ses_send_email" {
  statement {
    actions   = ["ses:SendEmail"]
    resources = ["*"]
  }
}
