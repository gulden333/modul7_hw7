namespace spp_pr7.Command;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("СИСТЕМА УПРАВЛЕНИЯ УМНЫМ ДОМОМ\n");
        
        var livingRoomLight = new Light("гостинная");
        var kitchenLight = new Light("кухня");
        var frontDoor = new Door("парадная");
        var bedroomThermostat = new Thermostat("спальня");
        var livingRoomTV = new TV("гостинная");
        var homeSecurity = new SecuritySystem("дом");
        
        var livingRoomLightOn = new LightOnCommand(livingRoomLight);
        var livingRoomLightOff = new LightOffCommand(livingRoomLight);
        var kitchenLightOn = new LightOnCommand(kitchenLight);
        var frontDoorOpen = new DoorOpenCommand(frontDoor);
        var frontDoorClose = new DoorCloseCommand(frontDoor);
        var tempIncrease = new TemperatureIncreaseCommand(bedroomThermostat);
        var tempDecrease = new TemperatureDecreaseCommand(bedroomThermostat);
        var tvOn = new TVOnCommand(livingRoomTV);
        var tvOff = new TVOffCommand(livingRoomTV);
        var securityArm = new SecurityArmCommand(homeSecurity);
        var securityDisarm = new SecurityDisarmCommand(homeSecurity);
        
        var goodNightMacro = new MacroCommand(
            new List<ICommand> { livingRoomLightOff, frontDoorClose, securityArm },
            "Режим 'Спокойной ночи'"
        );

        var welcomeHomeMacro = new MacroCommand(
            new List<ICommand> { livingRoomLightOn, tvOn, securityDisarm },
            "Режим 'Добро пожаловать домой'"
        );
        
        var invoker = new SmartHomeInvoker();
        
        Console.WriteLine("1. ТЕСТИРОВАНИЕ ОСНОВНЫХ КОМАНД:");
        Console.WriteLine("--------------------------------");

        invoker.ExecuteCommand(livingRoomLightOn);
        invoker.ExecuteCommand(kitchenLightOn);
        invoker.ExecuteCommand(frontDoorOpen);
        invoker.ExecuteCommand(tempIncrease);
        invoker.ExecuteCommand(tempIncrease);
        invoker.ExecuteCommand(tvOn);
        
        Console.WriteLine("\n2. ТЕСТИРОВАНИЕ ОТМЕНЫ:");
        Console.WriteLine("--------------------------------");
        
        invoker.UndoLastCommand(); // Отменить TV
        invoker.UndoLastCommand(); // Отменить температуру
        invoker.RedoLastUndoneCommand(); // Повторить температуру
        
        Console.WriteLine("\n3. ТЕСТИРОВАНИЕ МАКРОКОМАНД:");
        Console.WriteLine("--------------------------------");
        
        invoker.ExecuteCommand(goodNightMacro);
        invoker.UndoLastCommand(); // Отменить макрокоманду
        
        Console.WriteLine("\n4. ТЕСТИРОВАНИЕ ОБРАБОТКИ ОШИБОК:");
        Console.WriteLine("--------------------------------");
        
        var tempInvoker = new SmartHomeInvoker();
        tempInvoker.UndoLastCommand();
        tempInvoker.RedoLastUndoneCommand();
        
        Console.WriteLine("\n5. ИСТОРИЯ КОМАНД:");
        Console.WriteLine("--------------------------------");
        
        invoker.ShowCommandHistory();
        invoker.ShowUndoneCommands();
        
        Console.WriteLine("\n6. СОСТОЯНИЕ УСТРОЙСТВ:");
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"свет в гостинной: {(livingRoomLight.IsOn ? "ВКЛ" : "ВЫКЛ")}");
        Console.WriteLine($"свет на кухне: {(kitchenLight.IsOn ? "ВКЛ" : "ВЫКЛ")}");
        Console.WriteLine($"парадная дверь: {(frontDoor.IsOpen ? "ОТКРЫТА" : "ЗАКРЫТА")}");
        Console.WriteLine($"температура в спальне: {bedroomThermostat.Temperature}°C");
        Console.WriteLine($"телевизор: {(livingRoomTV.IsOn ? "ВКЛ" : "ВЫКЛ")}");
        Console.WriteLine($"сигнализация: {(homeSecurity.IsArmed ? "АКТИВИРОВАНА" : "ВЫКЛ")}");

        Console.WriteLine("\nДЕМОНСТРАЦИЯ ЗАВЕРШЕНА");
    }
}
