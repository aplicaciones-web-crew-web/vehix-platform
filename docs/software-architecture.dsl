workspace "Vehix - Vehicle Monitoring Platform" {

model {
  user = person "User" "Owner or operator who wants to monitor and manage their vehicles"

  softwareSystem = softwareSystem "Vehix Monitoring Platform" "Platform to monitor vehicle health, manage subscriptions, analyze usage, and more" {
    
    webApplication = container "Vehix Web Application" "Delivers static content and the Vue.js frontend" {
      tags "webapp"
      technology "HTML, CSS, JavaScript"
    }

    singlePageApplication = container "Vehix Single Page Application" "Provides an interactive web UI for users to manage vehicles, profiles, and access data" {
      tags "spa"
      technology "JavaScript, Vue 3, PrimeVue, Axios, Pinia, Vue-Router"
    }

    apiApplication = container "Vehix API Application" "Handles all core functionalities exposed via a JSON/HTTPS API" {
      tags "api"
      technology "C#, ASP.NET Core, Entity Framework Core"

      iam = component "Identity and Access Management" "Handles authentication, authorization, and account security" "ASP.NET Component"
      assets = component "Assets and Resource Management" "Manages vehicle data, diagnostics, and resources" "ASP.NET Component"
      profiles = component "Profiles and References" "Handles user profiles, roles, preferences, and vehicle associations" "ASP.NET Component"
      payments = component "Subscription and Payments" "Handles subscription plans, payment processing, and billing history" "ASP.NET Component"
      monitoring = component "Service Operation and Monitoring" "Tracks system health, API usage, error reporting, and logs" "ASP.NET Component"
      analytics = component "Analytics" "Performs data aggregation, trends, usage patterns, and performance KPIs" "ASP.NET Component"
    }

    database = container "Database" "Stores all Vehix data including users, vehicles, diagnostics, payments, and more" {
      tags "database"
      technology "MySQL Server"
    }
  }

  # Context
  user -> softwareSystem "Uses to monitor and manage vehicle data and subscriptions"

  # Container level
  user -> webApplication "Visits vehix monitoring platform using" "HTTPS"
  webApplication -> singlePageApplication "Delivers to browser"
  user -> singlePageApplication "Interacts with vehix platform"
  singlePageApplication -> apiApplication "Makes API calls to" "JSON/HTTPS"
  apiApplication -> database "Reads from and writes to"

  # Component level relationships
  iam -> database "Reads from and writes to"
  assets -> database "Reads from and writes to"
  profiles -> database "Reads from and writes to"
  payments -> database "Reads from and writes to"
  monitoring -> database "Reads from and writes to"
  analytics -> database "Reads from and writes to"

# Inter-component interactions (sin relación inválida)
assets -> profiles "Gets owner details linked to a vehicle"
payments -> iam "Validates user access based on subscription"
analytics -> assets "Aggregates diagnostics and usage data"
analytics -> payments "Analyzes subscription usage trends"
monitoring -> iam "Monitors auth activity and errors"
monitoring -> assets "Tracks API usage and exceptions"
monitoring -> payments "Logs billing-related activity"
iam -> profiles "Manages access and roles"

}

views {
  systemContext softwareSystem "SystemContext" {
    include *
    autoLayout
  }

  container softwareSystem "Containers" {
    include *
    autoLayout
  }

  component apiApplication "Components" {
    include *
    autoLayout
  }

  theme default

  styles {
    element "person" {
      shape Person
      background #08427B
    }

    element "webapp" {
      shape Box
      background #1168BD
    }

    element "spa" {
      shape WebBrowser
      background #00BB7A
    }

    element "api" {
      shape Box
      background #85BBF0
    }

    element "database" {
      shape Cylinder
      background #438DD5
    }
  }
}
}
