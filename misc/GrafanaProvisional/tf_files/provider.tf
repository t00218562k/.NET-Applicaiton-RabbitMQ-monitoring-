terraform {
    required_providers {
        grafana = {
            source = "grafana/grafana"
        }
    }
}

provider "grafana" {
    url = "http://localhost:3000/"
    auth = "eyJrIjoiRmhBNGxyc1V6TFdZM3phRmtzWGZBWklsbzlwOG9BV2kiLCJuIjoiVGVycmFmb3JtIiwiaWQiOjF9"
}