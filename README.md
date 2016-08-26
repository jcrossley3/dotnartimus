# dotnartimus

Experiments with dotnet, specifically integrating with Apache ActiveMQ
Artemis via AMQP

First, download Artemis 1.3.0 from
[here](https://activemq.apache.org/artemis/download.html), unpack it
somewhere, and run it:

    $ apache-artemis-1.3.0/bin/artemis create --silent ~/my-server
    $ ~/my-server/bin/artemis run

Once Artemis is ready, run the app:

    $ dotnet restore
    $ dotnet run
