resource "grafana_rule_group" "my_rule_group" {
    name = "My Alert Rules"
    folder_uid = grafana_folder.rule_folder.uid
    interval_seconds = 60
    org_id = 1

    rule {
        name = "Server Down"
        condition = "A"
        for = "0s"

        // Query the datasource.
        data {
            ref_id = "A"
            relative_time_range {
                from = 600
                to = 0
            }
            datasource_uid = grafana_data_source.prometheus.uid

            model = jsonencode({
                query = "up = 0"
                refId = "A"
            })
        }
    }
}