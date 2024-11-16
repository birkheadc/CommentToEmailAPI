resource "aws_iam_policy" "cloudwatch_put_metrics" {
  name   = "CloudwatchPutMetrics_${var.app_name}_${var.stage_name}"
  path   = "/"
  policy = data.aws_iam_policy_document.cloudwatch_put_metrics.json
}

resource "aws_iam_policy" "ses_send_email" {
  name   = "SESSendEmail_${var.app_name}_${var.stage_name}"
  path   = "/"
  policy = data.aws_iam_policy_document.ses_send_email.json
}
