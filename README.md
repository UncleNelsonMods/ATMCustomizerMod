# ATM Customizer Mod for Schedule I

A simple mod that lets you customize the text on ATM buttons in Schedule I.

## Features

- Changes the "DEPOSIT" and "WITHDRAW" text on ATM buttons to custom text
- Configurable through a simple JSON file
- No in-game controls required - works automatically

## Installation

1. Make sure you have [MelonLoader](https://github.com/LavaGang/MelonLoader) installed for Schedule I
2. Download the latest `ATMCustomizerMod.dll` from the releases
3. Place the `ATMCustomizerMod.dll` file in your `<Schedule I>/Mods/` folder
4. (Optional) Create a `ATMCustomizerMod.json` file in your `<Schedule I>/Mods/` folder to customize the button text

## Configuration

You can customize the ATM button text by editing the `ATMCustomizerMod.json` file:

```json
{
  "IsEnabled": true,
  "DepositText": "DEPOSIT CASH",
  "WithdrawText": "WITHDRAW CASH"
}
```

- `IsEnabled`: Set to `true` to enable the mod, `false` to disable
- `DepositText`: The text to display on the deposit button
- `WithdrawText`: The text to display on the withdraw button

If the config file doesn't exist, it will be created automatically with default values the first time you run the mod.

## Examples

Here are some fun text ideas you can use:

### Standard:
```json
{
  "DepositText": "DEPOSIT CASH",
  "WithdrawText": "WITHDRAW CASH"
}
```

### Aggressive:
```json
{
  "DepositText": "DUMP MONEY",
  "WithdrawText": "GRAB CASH"
}
```

### Friendly:
```json
{
  "DepositText": "SAVE MONEY",
  "WithdrawText": "GET MONEY"
}
```

### Silly:
```json
{
  "DepositText": "FEED ATM",
  "WithdrawText": "MILK ATM"
}
```

## Building from Source

### Requirements
- .NET 6.0 SDK or later
- Visual Studio 2019/2022 or another compatible IDE

### Steps
1. Clone this repository
2. Open the solution in your IDE
3. Ensure the `GamePath` in `build.bat` points to your Schedule I installation
4. Run the `build.bat` script or build the solution from your IDE

## License

This project is open source. Feel free to modify and distribute as needed. 