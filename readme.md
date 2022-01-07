This is code from _Distributed Transactions and Eventual Consistency_ technical session demos.

# Scenario
Trip: 
1. Buy ticket
2. Book flight
3. Book hotel

# Examples
1. [Event choreography](/EventChoreography) using [Mass Transit messaging](https://masstransit-project.com/usage/messages.html)
2. [Saga](/Saga) using [Chronicle](https://github.com/snatch-dev/Chronicle)

# Usage
1. Run the project
2. Go to swagger UI (`https://localhost:<port number>/swagger/index.html`)
3. Execute operation
   1. `GET ​/Trip​/Order`
   2. `GET ​/Trip​/OrderWithException` (Hotel booking is throwing exception)