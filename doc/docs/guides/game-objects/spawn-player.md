---
sidebar_position: 3
title: Spawn Player
---
# Player Game Objects

Mirage’s multiplayer HLAPI system handles player game objects differently than non-player game objects. When a new player joins the game (when a new client connects to the server), that player’s game object becomes a "local player" game object on the client of that player, and Unity associates the player’s connection with the player’s game object. Unity associates one player game object for each person playing the game, and routes networking Server RPC Calls to that individual game object. A player cannot invoke a Server RPC Call on another player’s game object, only their own.

The `NetworkBehaviour` class (which you derive from to create your network scripts) has a property called `IsLocalPlayer`. On each client’s player game object, Mirage sets that property to true on the `NetworkBehaviour` script and invokes the `OnStartLocalPlayer` callback on the object's `NetworkIdentity`. This means each client has a different game object set up like this because on each client a different game object is the one that represents the local player. The diagram below shows two clients and their local players.

![In this diagram, the circles represent the player game objects marked as the local player on each client](/img/guides/game-objects/network-local-players.png)

Only the player game object that is "yours" (from your point of view as the player) has the `IsLocalPlayer` flag set. Usually, you should set this flag in the script to determine whether to process input, whether to make the camera track the game object or do any other client-side things that should only occur for the player belonging to that client.

Player game objects represent the player (that is, the person playing the game) on the server, and run Server RPC Calls from the player’s client. These Server RPC Calls are secure client-to-server remote procedure calls. In this server-authoritative system, other non-player server-side game objects cannot receive Server RPC Calls directly from client-side game objects. This is both for security, and to reduce the complexity of building your game. By routing all incoming Server RPC Calls from users through the player game object, you can ensure that these messages come from the right place, the right client, and can be handled in a central location.

The `CharacterSpawner` component adds a player every time a client connects to the server. In some situations though, you might want it not to add players until an input event happens - such as a user pressing a “start” button on the controller. To disable automatic player creation, you may want to write your own `CharacterSpawner` component and wait for the `AddPlayerMessage` message to be sent from the client.
