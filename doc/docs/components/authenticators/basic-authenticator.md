# Basic Authenticator

Mirage includes a Basic Authenticator in the Mirage / Authenticators folder which just uses a simple username and password.
-   Drag the Basic Authenticator script to the inspector of the object in your scene that has Network Manager
-   The Basic Authenticator component will automatically be assigned to the Authenticator field in Network Manager

When you're done, it should look like this:

![Inspector showing Basic Authenticator component](/img/components/authenticators/Basic.png)

:::note
You don't need to assign anything to the event lists unless you want to subscribe to the events in your own code for your own purposes. Mirage has internal listeners for both events.
:::
