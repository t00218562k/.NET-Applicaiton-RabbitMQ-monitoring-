resource "grafana_contact_point" "my_contact_points"{
    name = "My Contact Points"

    email {
        addresses = ["joseph.diggins@students.ittralee.ie"]
        message = "{{ len .Alerts.Firing }} firing."
        subject = "{{ template \"default.title\" .}}"
        single_email = true
    }

    teams {
        url = "https://continuumcommerce.webhook.office.com/webhookb2/fd7237d2-c3a6-488d-b22e-d541be962ef2@777450a9-dbe8-4453-ac19-6cdfb6531b28/IncomingWebhook/bd20ea9243ae41eb908f0fde8169e87e/6ed226b5-4ed6-435f-b173-4c2beaa88ee9"
        title = "{{ template \"default.title\" .}}"
        message = "{{ len .Alerts.Firing }} firing."
    }
}