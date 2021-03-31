# ThreadedATMSimulator
ATM Simulator with threading.

* Completed Assignment

---

# ThreadedATMSimulator

This README file is written in Markdown format, it can be opened in a text editor / Markdown reader or a web browser.
# This is the readme file for the ATM Simulator Assignment for Team 18

## Team Members: 
* [ch6li3](https://github.com/ch6li3)
* [wdunkelheit](https://github.com/wdunkelheit)
* [timeisthelimit](https://github.com/timeisthelimit)

---

# BUTTONS

## Pinpad:
* Each numbered `button` will input its number into a given text prompt on the screen.

## Accept:
* The accept `button` will confirm to the text promp on the screen that your entry is conpleted.

## Clear:
* The clear `button` will clear the text prompt on screen so that you can populate it with new data.

## Cancel:
* The cancel `button` will return you to the previous state or cancel your current course of action.

## Display Buttons:
* Display `buttons` work as they would on a normal ATM, they correspond with the text labels on the ATM display to the side of them.

---

# Race Condition
* The `race condition` is simulated by delaying the input of the user for 5 seconds to give you enough time to access other ATM Windows to select options on their displays.
* The `race condition` can be toggled on and off on the Central Bank Computer Window
* The `race condition` is independant of the locking functionality and can be used with or without using locking as a workaround.

# Locking
* `Locking` can be enabled or disabled in the Central Banking Computer Window.
* `Locking` makes other 'Threads' wait their turn before they can access a function that contains integral code.
* You can use `locking` with or without the `Race Condition` turned on.

# ATM Forms
* When an ATM `form` is closed the Central Banking Computer will show the new count of how many ATMs are active.
* If you select Cancel on the Account Number page it will tell you to take your card.

