resource "grafana_data_source" "prometheus" {
  type = "prometheus"
  name = "ds_Prometheus"
  url = "http://prometheus:9090"
}

resource "grafana_folder" "rule_folder" {
    title = "My Rule Folder"
}