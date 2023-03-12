resource "grafana_notification_policy" "my_notifcation_policy" {
    contact_point = grafana_contact_point.my_contact_points.name
    group_by = ["alertname"]

    group_wait = "45s"
    group_interval = "6m"
    repeat_interval = "3h"

    policy {
        matcher {
            label = "up"
            match = "="
            value = "0"
        }
        contact_point = grafana_contact_point.my_contact_points.name
        group_by = ["alertname"]
    }
}