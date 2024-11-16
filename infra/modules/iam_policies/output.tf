output "cloudwatch_put_metrics" {
  value = aws_iam_policy.cloudwatch_put_metrics.arn
}

output "ses_send_email" {
  value = aws_iam_policy.ses_send_email.arn
}
