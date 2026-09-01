# Durak

A C# implementation of the traditional Russian card game **Durak**, featuring customizable player setups, AI opponents, and an in-game rules reference.

## Overview

**Durak** is a digital implementation of the traditional card game built in C#. Players can configure a game with human and AI opponents, customize their player identity, and play through a complete game of Durak.

The project focuses on implementing the rules and mechanics of the card game while providing an accessible interface for configuring and playing a match.

## Features

### Game Setup

Before starting a game, players can customize their match by:

* Choosing between **1–4 players**
* Adding **1–3 AI opponents**
* Choosing a player name
* Selecting a player icon
* Configuring the desired player setup before starting

### Gameplay

The application implements the core mechanics required to play Durak, including:

* Card drawing and dealing
* Player turns
* Attacking and defending
* Card comparisons
* Trump suit mechanics
* Successful and unsuccessful defences
* Managing the deck throughout the game
* Player elimination and game progression
* Determining the final winner

### AI Opponents

Players can compete against computer-controlled opponents.

The AI system allows games to be played without requiring multiple human players, providing an opportunity to implement decision-making logic within the game's rules.

### Rules Reference

The game includes an accessible rules reference that can be opened both:

* Before starting a game
* During gameplay

This allows players to quickly check the rules without having to leave the application.

## Technologies

* **C#**
* **Object-Oriented Programming**

## Technical Highlights

This project focuses heavily on object-oriented programming and modeling the components of a card game as interacting objects.

Key programming concepts demonstrated include:

* Object-oriented class design
* Encapsulation of game state
* Card and deck management
* Turn-based game-state management
* Rule validation
* Player and AI behavior
* Randomization and shuffling
* Conditional game logic
* User input and configuration
* Managing multiple possible game states

## Game Architecture

The game is structured around the core entities and systems required to represent a game of Durak.

These include concepts such as:

* **Cards** — Represent individual playing cards and their properties.
* **Deck** — Handles the card collection, shuffling, and drawing.
* **Players** — Tracks player-specific information such as their hand, name, and icon.
* **AI Players** — Extends player functionality with computer-controlled decision-making.
* **Game State** — Controls turns, attacks, defences, and overall progression.
* **Rules** — Defines and validates the rules governing gameplay.

## User Experience

The application was designed to make the game approachable for players who may not already know the rules.

The setup screen allows players to configure their match before playing, while the persistent rules reference assists without interrupting an active game.

## Purpose

This project was created to explore object-oriented programming through the development of a complete, rules-driven game.

Implementing Durak provided an opportunity to translate a relatively complex set of real-world rules into programmatic logic while handling multiple players, AI opponents, and changing game states.

## Status

✅ **Playable Project**

The core Durak gameplay and player configuration systems have been implemented.
