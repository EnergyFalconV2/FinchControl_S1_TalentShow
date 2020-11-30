using FinchAPI;
using System;
using System.Collections.Generic;
namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Voss, Connor
    // Dated Created: 11/24/2020
    // Last Modified: 11/28/2020
    //
    // **************************************************

    /// <summary>
    /// User Commands
    /// </summary>
    public enum Command
    {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        GETTEMPERATURE,
        DONE
    }


    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }


        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":
                        AlarmSystemDisplayMenuScreen(finchRobot);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);


            #region TALENT SHOW

            /// <summary>
            /// *****************************************************************
            /// *                     Talent Show Menu                          *
            /// *****************************************************************
            /// </summary>
            static void TalentShowDisplayMenuScreen(Finch finchRobot)
            {
                Console.CursorVisible = true;

                bool quitTalentShowMenu = false;
                string menuChoice;

                do
                {
                    DisplayScreenHeader("Talent Show Menu");

                    //
                    // get user menu choice
                    //
                    Console.WriteLine("\ta) Light and Sound");
                    Console.WriteLine("\tb) Dance");
                    Console.WriteLine("\tc) Mixing it Up");
                    Console.WriteLine("\td) ");
                    Console.WriteLine("\tq) Main Menu");
                    Console.Write("\t\tEnter Choice:");
                    menuChoice = Console.ReadLine().ToLower();

                    //
                    // process user menu choice
                    //
                    switch (menuChoice)
                    {
                        case "a":
                            TalentShowDisplayLightAndSound(finchRobot);
                            break;

                        case "b":
                            TalentShowDisplayDance(finchRobot);
                            break;

                        case "c":
                            TalentShowDisplayMixingItUp(finchRobot);
                            break;

                        case "d":

                            break;

                        case "q":
                            quitTalentShowMenu = true;
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter a letter for the menu choice.");
                            DisplayContinuePrompt();
                            break;
                    }

                } while (!quitTalentShowMenu);
            }

            /// <summary>
            /// *****************************************************************
            /// *               Talent Show > Light and Sound                   *
            /// *****************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            static void TalentShowDisplayLightAndSound(Finch finchRobot)
            {
                Console.CursorVisible = false;

                DisplayScreenHeader("Light and Sound");

                Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
                DisplayContinuePrompt();

                for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
                {
                    finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                    finchRobot.noteOn(lightSoundLevel * 100);
                }

                DisplayMenuPrompt("Talent Show");

                finchRobot.noteOff();
                finchRobot.setLED(0, 0, 0);
            }

            /// <summary>
            /// *******************************************************
            /// *               Talent Show > Dance                   *
            /// *******************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            static void TalentShowDisplayDance(Finch finchRobot)
            {
                Console.CursorVisible = false;

                DisplayScreenHeader("Dance");

                Console.WriteLine("\tThe Finch robot will now show off its dance moves!");


                for (int i = 0; i < 3; i++)
                {
                    finchRobot.setMotors(255, 128);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(128, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                }

                DisplayContinuePrompt();

                DisplayMenuPrompt("Talent Show");
            }

            /// <summary>
            /// *************************************************************
            /// *               Talent Show > Mixing It Up                  *
            /// *************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            static void TalentShowDisplayMixingItUp(Finch finchRobot)
            {
                Console.CursorVisible = false;

                DisplayScreenHeader("Mixing It Up");

                Console.WriteLine("\tThe Finch robot will now show off its glowing talent AND dance moves!");
                DisplayContinuePrompt();

                for (int i = 0; i < 3; i++)
                {
                    finchRobot.noteOn(880);
                    finchRobot.wait(1000);
                    finchRobot.noteOn(523);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(255, 128);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(128, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.noteOff();
                }

                DisplayMenuPrompt("Talent Show");
            }

            #endregion

            #region DATA RECORDER

            /// <summary>
            /// *******************************************************************
            /// *                     Data Recorder Menu                          *
            /// *******************************************************************
            /// </summary>

            static void DataRecorderDisplayMenuScreen(Finch finchRobot)
            {
                Console.CursorVisible = true;

                bool quitDataRecorderMenu = false;

                string menuChoice;
                int numberOfDataPoints = 0;
                double dataPointFrequency = 0;
                double[] temperatures = null;
                double[] lightSensors = null;

                do
                {
                    DisplayScreenHeader("\tData Recorder");

                    //
                    // get user menu choice
                    //
                    Console.WriteLine("\ta) Number of Data Points");
                    Console.WriteLine("\tb) Frequency of Data Points");
                    Console.WriteLine("\tc) Get Temperature Data");
                    Console.WriteLine("\td) Get Light Sensor Data");
                    Console.WriteLine("\te) Show Data");
                    Console.WriteLine("\tq) Main Menu");
                    Console.Write("\t\tEnter Choice:");
                    menuChoice = Console.ReadLine().ToLower();

                    //
                    // process user menu choice
                    //
                    switch (menuChoice)
                    {
                        case "a":
                            numberOfDataPoints = DataRecorderDisplayNumberOfDataPoints(finchRobot);
                            break;

                        case "b":
                            dataPointFrequency = DataRecorderDisplayFrequencyOfDataPoints(finchRobot);
                            break;

                        case "c":
                            if (numberOfDataPoints == 0 || dataPointFrequency == 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("\t\tPlease indicate the number and frequency of Data Points first.");
                                Console.WriteLine();
                                DisplayContinuePrompt();
                            }
                            else
                            {
                                temperatures = DataRecorderDisplayGetTemperatureData(numberOfDataPoints, dataPointFrequency, finchRobot);
                            }
                            break;


                        case "d":
                            if (numberOfDataPoints == 0 || dataPointFrequency == 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("\t\tPlease indicate the number and frequency of Data Points first.");
                                Console.WriteLine();
                                DisplayContinuePrompt();
                            }
                            else
                            {
                                lightSensors = DataRecorderDisplayGetLightSensorData(numberOfDataPoints, dataPointFrequency, finchRobot);
                            }
                            break;

                        case "e":
                            DataRecorderDisplayShowData(temperatures, lightSensors);
                            break;

                        case "q":
                            quitDataRecorderMenu = true;
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter a letter for the menu choice.");
                            DisplayContinuePrompt();
                            break;

                    }
                } while (!quitDataRecorderMenu);
            }

            static void DataRecorderDisplayTable(double[] temperatures, double[] lightSensorAVG)
            {

                Console.WriteLine(
                    "Recording".PadLeft(15) +
                    "Temperature".PadLeft(15)
                    );

                for (int index = 0; index < temperatures.Length; index++)
                {
                    Console.WriteLine(
                        (index + 1).ToString().PadLeft(15) +
                        temperatures[index].ToString("n2").PadLeft(15));

                }

                Console.WriteLine();

                Console.WriteLine(
                    "Recording".PadLeft(15) +
                    "Light Sensor Average".PadLeft(30)
                    );

                for (int index = 0; index < lightSensorAVG.Length; index++)
                {
                    Console.WriteLine(
                        (index + 1).ToString().PadLeft(15) +
                        lightSensorAVG[index].ToString("n2").PadLeft(15)
                        );
                }

            }

            /// <summary>
            /// *************************************************************************
            /// *               Data Recorder > Number of Data Points                   *
            /// *************************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            static int DataRecorderDisplayNumberOfDataPoints(Finch finchRobot)
            {
                int numberOfDataPoints;
                Console.CursorVisible = false;

                DisplayScreenHeader("Number of Data Points");

                Console.Write("\tEnter the number of Data Points: ");

                //
                // validate input
                //
                int.TryParse(Console.ReadLine(), out numberOfDataPoints);

                Console.WriteLine();
                Console.WriteLine($"\tNumber of Data Points: {numberOfDataPoints}");

                DisplayMenuPrompt("Data Recorder");

                return numberOfDataPoints;
            }


            /// <summary>
            /// ****************************************************************************
            /// *               Data Recorder > Frequency of Data Points                   *
            /// ****************************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            static double DataRecorderDisplayFrequencyOfDataPoints(Finch finchRobot)
            {
                double dataPointFrequency;
                Console.CursorVisible = false;

                DisplayScreenHeader("Frequency of Data Points");

                Console.WriteLine("\tEnter the Frequency of Data Points [seconds]: ");

                //
                // validate input
                //
                double.TryParse(Console.ReadLine(), out dataPointFrequency);

                Console.WriteLine();
                Console.WriteLine($"\tFrequency of Data Points: {dataPointFrequency}");


                DisplayMenuPrompt("Data Recorder");

                return dataPointFrequency;
            }

            /// <summary>
            /// ************************************************************************
            /// *               Data Recorder > Get Temperature Data                   *
            /// ************************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            static double[] DataRecorderDisplayGetTemperatureData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
            {
                double[] temperatures = new double[numberOfDataPoints];
                double[] lightSensorAVG = new double[numberOfDataPoints];
                Console.CursorVisible = false;

                DisplayScreenHeader("Get Data");

                Console.WriteLine($"\tNumber of Data Points: {numberOfDataPoints}");
                Console.WriteLine($"\tFrequency of Data Points [seconds]: {dataPointFrequency}");
                Console.WriteLine();

                Console.WriteLine("\tThe Finch Robot is ready to record the temperatures. Press any key to begin.");
                Console.ReadKey();
                Console.WriteLine();

                double temperature; ;
                double temperatureF;
                int milliseconds;
                for (int index = 0; index < numberOfDataPoints; index++)
                {
                    temperature = finchRobot.getTemperature();
                    temperatureF = temperature * 1.8 + 32;
                    Console.WriteLine($"\t\tTemperature Reading {index + 1}: {temperatureF}");

                    Console.WriteLine();

                    temperatures[index] = temperatureF;

                    milliseconds = (int)(dataPointFrequency * 1000);
                    finchRobot.wait(milliseconds);

                }

                Console.WriteLine();
                Console.WriteLine("\tThe data recording is complete.");

                DisplayContinuePrompt();

                return temperatures;

            }

            /// <summary>
            /// *************************************************************************
            /// *               Data Recorder > Get Light Sensor Data                   *
            /// *************************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            static double[] DataRecorderDisplayGetLightSensorData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
            {
                double[] lightSensorAVG = new double[numberOfDataPoints];
                Console.CursorVisible = false;

                DisplayScreenHeader("Get Data");

                Console.WriteLine($"\tNumber of Data Points: {numberOfDataPoints}");
                Console.WriteLine($"\tFrequency of Data Points [seconds]: {dataPointFrequency}");
                Console.WriteLine();

                Console.WriteLine("\tThe Finch Robot is ready to record the light sensors. Press any key to begin.");
                Console.ReadKey();
                Console.WriteLine();

                double lightSensorL;
                double lightSensorR;
                int milliseconds;
                for (int index = 0; index < numberOfDataPoints; index++)
                {
                    lightSensorL = finchRobot.getLeftLightSensor();
                    lightSensorR = finchRobot.getRightLightSensor();
                    Console.WriteLine($"\t\tLeft Light Sensor Reading {index + 1}: {lightSensorL}");
                    Console.WriteLine($"\t\tRight Light Sensor Reading {index + 1}: {lightSensorR}");
                    lightSensorAVG[index] = lightSensorL + lightSensorR / numberOfDataPoints;
                    milliseconds = (int)(dataPointFrequency * 1000);
                    finchRobot.wait(milliseconds);
                }


                Console.WriteLine();
                Console.WriteLine("\tThe data recording is complete.");

                DisplayContinuePrompt();

                return lightSensorAVG;


            }

            /// <summary>
            /// ***********************************************************
            /// *               Data Recorder > Data Set                  *
            /// ***********************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            static void DataRecorderDisplayShowData(double[] temperatures, double[] lightSensorAVG)
            {
                Console.CursorVisible = false;

                DisplayScreenHeader("Data Set");

                DataRecorderDisplayTable(temperatures, lightSensorAVG);

                DisplayContinuePrompt();

                DisplayMenuPrompt("Data Recorder");
            }


            #endregion

            #region ALARM SYSTEM

            /// <summary>
            /// ******************************************************************
            /// *                     Alarm System Menu                          *
            /// ******************************************************************
            /// </summary>

            static void AlarmSystemDisplayMenuScreen(Finch finchRobot)
            {
                Console.CursorVisible = true;

                bool quitMenu = false;
                string menuChoice;

                string sensorsToMonitor = "";
                string rangeType = "";
                int minMaxThresholdValue = 0;
                int timeToMonitor = 0;

                do
                {
                    DisplayScreenHeader("\tAlarm System");

                    //
                    // get user menu choice
                    //
                    Console.WriteLine("\ta) Set Sensors to Monitor");
                    Console.WriteLine("\tb) Set Range Type");
                    Console.WriteLine("\tc) Set Maximum/Minimum Threshold Value");
                    Console.WriteLine("\td) Set Time to Monitor");
                    Console.WriteLine("\te) Set Alarm");
                    Console.WriteLine("\tq) Main Menu");
                    Console.Write("\t\tEnter Choice:");
                    menuChoice = Console.ReadLine().ToLower();

                    //
                    // process user menu choice
                    //
                    switch (menuChoice)
                    {
                        case "a":
                            sensorsToMonitor = AlarmSystemDisplaySensorToMonitor();
                            break;

                        case "b":
                            rangeType = AlarmSystemDisplayRangeType();
                            break;

                        case "c":
                            minMaxThresholdValue = AlarmSystemDisplaySetMinMaxThreshold(finchRobot, rangeType, sensorsToMonitor);
                            break;

                        case "d":
                            timeToMonitor = AlarmSystemTimeToMonitor();
                            break;

                        case "e":
                            if (sensorsToMonitor == "" || rangeType == "" || minMaxThresholdValue == 0 || timeToMonitor == 0)
                            {
                                Console.WriteLine("Please enter all required values.");
                                DisplayContinuePrompt();
                            }
                            else
                            {
                                AlarmSystemSetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor);
                            }

                            break;

                        case "q":
                            quitMenu = true;
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter a letter for the menu choice.");
                            DisplayContinuePrompt();
                            break;

                    }
                } while (!quitMenu);

            }

            static void AlarmSystemSetAlarm(Finch finchRobot, string sensorsToMonitor, string rangeType, int minMaxThresholdValue, int timeToMonitor)
            {
                DisplayScreenHeader("Set Alarm");

                Console.WriteLine("\tAlarm Settings");
                Console.WriteLine($"\t\tSensor to Monitor: {sensorsToMonitor}");
                Console.WriteLine($"\t\tRange Type: {rangeType}");
                Console.WriteLine($"\t\tMin/Max Threshold: {minMaxThresholdValue}");
                Console.WriteLine($"\t\tTime to Monitor: {timeToMonitor}");


                Console.WriteLine();
                Console.WriteLine("Press any key to start the alarm system.");
                Console.CursorVisible = false;
                Console.ReadKey();
                Console.CursorVisible = true;

                int second = 1;
                bool thresholdExceeded = AlarmSystemLightThresholdExceeded(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue);

                while (!thresholdExceeded && second <= timeToMonitor)
                {
                    Console.SetCursorPosition(10, 12);
                    Console.WriteLine($"\t\tTime: {second++}");
                    finchRobot.wait(1000);
                    thresholdExceeded = AlarmSystemLightThresholdExceeded(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue);
                }

                bool thresholdExceededTemp = AlarmSystemTemperatureThresholdExceeded(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue);

                while (!thresholdExceededTemp && second <= timeToMonitor)
                {
                    Console.SetCursorPosition(10, 12);
                    Console.WriteLine($"\t\tTime: {second++}");
                    finchRobot.wait(1000);
                    thresholdExceededTemp = AlarmSystemTemperatureThresholdExceeded(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue);
                }

                bool thresholdExceededLAndT = AlarmSystemLightAndTemperatureThresholdExceeded(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue);

                while (!thresholdExceededLAndT && second <= timeToMonitor)
                {
                    Console.SetCursorPosition(10, 12);
                    Console.WriteLine($"\t\tTime: {second++}");
                    finchRobot.wait(1000);
                    thresholdExceededLAndT = AlarmSystemLightAndTemperatureThresholdExceeded(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue);
                }


                //
                // display status
                //
                if (second > timeToMonitor)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tThreshold Not Ecxeeded");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tThreshold Ecxeeded");

                }

                DisplayContinuePrompt();
            }



            static bool AlarmSystemLightThresholdExceeded(Finch finchRobot, string sensorsToMonitor, string rangeType, int minMaxThresholdValue)
            {
                //
                // get current light value
                //
                int currentLeftLightSensorValue = finchRobot.getLeftLightSensor();
                int currentRightLightSensorValue = finchRobot.getRightLightSensor();

                bool thresholdExceeded = false;
                switch (sensorsToMonitor)
                {
                    case "left light":
                        if (rangeType == "minimum")
                        {
                            thresholdExceeded = currentLeftLightSensorValue < minMaxThresholdValue;
                        }
                        else
                        {
                            thresholdExceeded = currentLeftLightSensorValue > minMaxThresholdValue;
                        }
                        break;

                    case "right light":
                        if (rangeType == "minimum")
                        {
                            thresholdExceeded = currentRightLightSensorValue < minMaxThresholdValue;
                        }
                        else
                        {
                            thresholdExceeded = currentRightLightSensorValue > minMaxThresholdValue;
                        }
                        break;

                    case "both lights":
                        if (rangeType == "minimum")
                        {
                            thresholdExceeded = (currentLeftLightSensorValue < minMaxThresholdValue) || (currentRightLightSensorValue < minMaxThresholdValue);
                        }
                        else
                        {
                            thresholdExceeded = (currentLeftLightSensorValue) > minMaxThresholdValue || (currentRightLightSensorValue > minMaxThresholdValue);
                        }
                        break;

                    default:
                        Console.WriteLine("Sensor value error");
                        DisplayContinuePrompt();
                        break;

                }

                return thresholdExceeded;
            }

            static bool AlarmSystemTemperatureThresholdExceeded(Finch finchRobot, string sensorsToMonitor, string rangeType, int minMaxThresholdValue)
            {
                //
                // get current temperature value
                //
                double currentTemperatureValue = finchRobot.getTemperature();

                bool thresholdExceededTemp = false;
                switch (sensorsToMonitor)
                {
                    case "temperature":
                        if (rangeType == "minimum")
                        {
                            thresholdExceededTemp = currentTemperatureValue < minMaxThresholdValue;
                        }
                        else
                        {
                            thresholdExceededTemp = currentTemperatureValue > minMaxThresholdValue;
                        }
                        break;

                    default:
                        Console.WriteLine("Sensor value error");
                        DisplayContinuePrompt();
                        break;
                }

                return thresholdExceededTemp;
            }

            static bool AlarmSystemLightAndTemperatureThresholdExceeded(Finch finchRobot, string sensorsToMonitor, string rangeType, int minMaxThresholdValue)
            {
                //
                // get current light value
                //
                int currentLeftLightSensorValue = finchRobot.getLeftLightSensor();
                int currentRightLightSensorValue = finchRobot.getRightLightSensor();
                double currentTemperatureValue = finchRobot.getTemperature();

                bool thresholdExceededLAndT = false;
                switch (sensorsToMonitor)
                {
                    case "temperature and lights":
                        if (rangeType == "minimum")
                        {
                            thresholdExceededLAndT = currentLeftLightSensorValue < minMaxThresholdValue || currentRightLightSensorValue < minMaxThresholdValue || currentTemperatureValue < minMaxThresholdValue;
                        }
                        else
                        {
                            thresholdExceededLAndT = currentLeftLightSensorValue > minMaxThresholdValue || currentRightLightSensorValue > minMaxThresholdValue || currentTemperatureValue > minMaxThresholdValue;
                        }
                        break;

                    default:
                        Console.WriteLine("Sensor value error");
                        DisplayContinuePrompt();
                        break;

                }

                return thresholdExceededLAndT;
            }

            /// <summary>
            /// get time to monitor from the user
            /// </summary>
            /// <returns>time to monitor</returns>
            static int AlarmSystemTimeToMonitor()
            {
                int timeToMonitor = 0;

                DisplayScreenHeader("Time to Minitor");

                Console.Write("\tEnter Time to Monitor: ");
                int.TryParse(Console.ReadLine(), out timeToMonitor);

                Console.WriteLine();
                Console.WriteLine($"Time to Monitor: {timeToMonitor}");

                DisplayContinuePrompt();

                return timeToMonitor;
            }

            /// <summary>
            /// get min/max threshold value for user
            /// </summary>
            /// <returns>min/max threshold value</returns>

            static int AlarmSystemDisplaySetMinMaxThreshold(Finch finchRobot, string rangeType, string sensorsToMonitor)
            {
                int minMaxThresholdValue = 0;

                DisplayScreenHeader("Mix/Max Threshold Value");

                Console.WriteLine($"\tAmbient Left Light Level: {finchRobot.getLeftLightSensor()}");
                Console.WriteLine($"\tAmbient Right Light Level: {finchRobot.getRightLightSensor()}");
                Console.WriteLine($"\tTemperature Level: {finchRobot.getTemperature()}");

                switch (sensorsToMonitor)
                {
                    case "left light":
                        Console.Write($"\tEnter the {rangeType} threshold value: ");
                        minMaxThresholdValue = Convert.ToInt32(Console.ReadLine());
                        break;

                    case "right light":
                        Console.Write($"\tEnter the {rangeType} threshold value: ");
                        minMaxThresholdValue = Convert.ToInt32(Console.ReadLine());
                        break;

                    case "both lights":
                        Console.Write($"\tEnter the {rangeType} threshold value: ");
                        minMaxThresholdValue = Convert.ToInt32(Console.ReadLine());
                        break;

                    case "temperature":
                        Console.Write($"\tEnter the {rangeType} threshold value: ");
                        minMaxThresholdValue = Convert.ToInt32(Console.ReadLine());
                        break;

                    case "temperature and lights":
                        Console.WriteLine($"\tEnter the threshold value for lights: ");
                        minMaxThresholdValue = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\tEnter the threshold value for temperature: ");
                        minMaxThresholdValue = Convert.ToInt32(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Please enter a threshold value.");
                        DisplayContinuePrompt();
                        break;
                }

                DisplayContinuePrompt();
                return minMaxThresholdValue;
            }

            /// <summary>
            /// get range type from user
            /// </summary>
            /// <returns>get range</returns>
            static string AlarmSystemDisplayRangeType()
            {
                string rangeType = "";

                DisplayScreenHeader("Range Type");

                Console.Write("\tEnter Range Type [minimum, maximum]: ");
                rangeType = Console.ReadLine();

                DisplayContinuePrompt();

                return rangeType;
            }

            /// <summary>
            /// get sensors to monitor from user
            /// </summary>
            /// <returns>sensors to monitor</returns>

            static string AlarmSystemDisplaySensorToMonitor()
            {
                string sensorsToMonitor = "";

                DisplayScreenHeader("Sensors To Monitor");

                Console.WriteLine("\tEnter Sensors to Monitor [left light, right light, both lights, temperature, temperature and lights] ");
                sensorsToMonitor = Console.ReadLine();

                DisplayContinuePrompt();

                return sensorsToMonitor;
            }
            #endregion

            #region USER PROGRAMMING

            /// <summary>
            /// **********************************************************************
            /// *                     User Programming Menu                          *
            /// **********************************************************************
            /// </summary>

            static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
            {
                string menuChoice;
                bool quitMenu = false;

                //
                // tuple to store all three command parameters
                //
                (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
                commandParameters.motorSpeed = 0;
                commandParameters.ledBrightness = 0;
                commandParameters.waitSeconds = 0;

                List<Command> commands = new List<Command>();

                do
                {
                    DisplayScreenHeader("User Programming Menu");

                    //
                    // get user menu choice
                    //
                    Console.WriteLine("\ta0 Set Command Parameters");
                    Console.WriteLine("\tb) Add Commands");
                    Console.WriteLine("\tc) View Commands");
                    Console.WriteLine("\td) Execute Commands");
                    Console.WriteLine("\tq) Quit");
                    Console.Write("\t\tEnter Choice:");
                    menuChoice = Console.ReadLine().ToLower();

                    //
                    // process user menu choice
                    //
                    switch (menuChoice)
                    {
                        case "a":
                            commandParameters = UserProgrammingDisplayGetCommandParameters();
                            break;

                        case "b":
                            UserProgrammingDisplayGetFinchCommands(commands);
                            break;

                        case "c":
                            UserProgrammingDisplayFinchCommands(commands);
                            break;

                        case "d":
                            UserProgrammingDisplayExecuteFinchCommands(finchRobot, commands, commandParameters);
                            break;

                        case "q":
                            quitMenu = true;
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter a letter for menu choice.");
                            DisplayContinuePrompt();
                            break;
                    }

                } while (!quitMenu);


            }
            /// <summary>
            /// ****************************************************
            /// *               Execute Commands                   *
            /// ****************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            /// <param name="commands">list of commands</param>
            /// <param name="commandParameters">tuple of command parameters</param>

            static void UserProgrammingDisplayExecuteFinchCommands(
                Finch finchRobot;
            List<Command> commands,
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {
                int motorSpeed = commandParameters.motorSpeed;
                int ledBrightness = commandParameters.ledBrightness;
                int waitMilliSeconds = (int)(commandParameters.waitSeconds * 1000);
                string commandFeedback = "";
                const int TURNING_MOTOR_SPEED = 100;

                DisplayScreenHeader("Execute Finch Commands");

                Console.WriteLine("\tThe Finch robot is ready to execute the list of commands.");
                DisplayContinuePrompt();

                foreach (Command command in commands)
                {
                    switch (command)
                    {
                        case Command.NONE:
                            break;

                        case Command.MOVEFORWARD:
                            finchRobot.setMotors(motorSpeed, motorSpeed);
                            commandFeedback = Command.MOVEFORWARD.ToString();
                            break;

                        case Command.MOVEBACKWARD:
                            finchRobot.setMotors(-motorSpeed, -motorSpeed);
                            commandFeedback = Command.MOVEBACKWARD.ToString();
                            break;

                        case Command.STOPMOTORS:
                            finchRobot.setMotors(0, 0);
                            commandFeedback = Command.STOPMOTORS.ToString();
                            break;

                        case Command.WAIT:
                            finchRobot.wait(waitMilliSeconds);
                            commandFeedback = Command.WAIT.ToString();
                            break;

                        case Command.TURNRIGHT:
                            finchRobot.setMotors(TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                            commandFeedback = Command.TURNRIGHT.ToString();
                            break;

                        case Command.TURNLEFT:
                            finchRobot.setMotors(-TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                            commandFeedback = Command.TURNLEFT.ToString();
                            break;

                        case Command.LEDON:
                            finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                            commandFeedback = Command.LEDON.ToString();
                            break;

                        case Command.LEDOFF:
                            finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                            commandFeedback = Command.LEDOFF.ToString();
                            break;

                        case Command.GETTEMPERATURE:
                            commandFeedback = $"Temperature: {finchRobot.getTemperature().ToString("n2")}\n";
                            break;

                        case Command.DONE:
                            commandFeedback = Command.DONE.ToString();
                            break;

                        default:

                            break;
                    }

                    Console.WriteLine($"\t{commandFeedback}");
                }

                DisplayContinuePrompt();

            }

            /// <summary>
            /// *************************************************
            /// *               Display Commands                *
            /// *************************************************
            /// </summary>
            /// <param name="commands">list of commands</param>

            static void UserProgrammingDisplayFinchCommands(List<Command> commands)
            {
                DisplayScreenHeader("Finch Robot Commands");

                foreach (Command command in commands)
                {
                    Console.WriteLine($"\t{command}");
                }

                DisplayContinuePrompt();

            }


            /// <summary>
            /// ********************************************************
            /// *               Get Commands From User                 *
            /// ********************************************************
            /// </summary>
            /// <param name="commands" >list of commands</param>

            static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
            {
                Command command = Command.NONE;

                DisplayScreenHeader("Finch Robot Commands");

                //
                // list commands
                //
                int commandCount = 1;
                Console.WriteLine("\tList of Available Commands");
                Console.WriteLine();
                Console.Write("\t-");
                foreach (string commandName in Enum.GetNames(typeof(Command)))
                {
                    Console.Write($"- {commandName.ToLower()} -");
                    if (commandCount % 5 == 0) Console.Write("-\n\t");
                    commandCount++;
                }
                Console.WriteLine();

                while (command != Command.DONE)
                {
                    Console.WriteLine("\tEnter Command: ");

                    if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                    {
                        commands.Add(command);
                    }
                    else
                    {
                        Console.WriteLine("\t\t********************************************");
                        Console.WriteLine("\t\tPlease enter a command from the list above.");
                        Console.WriteLine("\t\t********************************************");
                    }
                }

                //echo commands

                DisplayContinuePrompt();

            }

            /// <summary>
            /// ******************************************************************
            /// *               Get Command Parameters From User                 *
            /// ******************************************************************
            /// </summary>
            /// <returns>tuple of command parameters</returns>

            static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplayGetCommandParameters()
            {
                DisplayScreenHeader("Command Parameters");

                (int motorSpeed, int ledBrightness, double waitSeconds) = commandParameters;
                commandParameters.motorSpeed = 0;
                commandParameters.ledBrightness = 0;
                commandParameters.waitSeconds = 0;



                Console.WriteLine("\tEnter Motor Speed [1 - 255]: ", 1, 255, commandParameters.motorSpeed);
                Console.WriteLine("\tEnter LED Brightness [1 - 155]: ", 1, 255, commandParameters.ledBrightness);
                Console.WriteLine("\tEnter Wait in Seconds: ", 0, 10, commandParameters.waitSeconds);

                Console.WriteLine();
                Console.WriteLine($"\tMotor Speed: {commandParameters.motorSpeed}");
                Console.WriteLine($"\tLED Brightness: {commandParameters.ledBrightness}");
                Console.WriteLine($"\tWait command duration: {commandParameters.waitSeconds}");

                DisplayContinuePrompt();

                return commandParameters;

            }

            #endregion

            #region FINCH ROBOT MANAGEMENT

            /// <summary>
            /// *****************************************************************
            /// *               Disconnect the Finch Robot                      *
            /// *****************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            static void DisplayDisconnectFinchRobot(Finch finchRobot)
            {
                Console.CursorVisible = false;

                DisplayScreenHeader("Disconnect Finch Robot");

                Console.WriteLine("\tAbout to disconnect from the Finch robot.");
                DisplayContinuePrompt();

                finchRobot.disConnect();

                Console.WriteLine("\tThe Finch robot is now disconnected.");

                DisplayMenuPrompt("Main Menu");
            }

            /// <summary>
            /// *****************************************************************
            /// *                  Connect the Finch Robot                      *
            /// *****************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            /// <returns>notify if the robot is connected</returns>
            static bool DisplayConnectFinchRobot(Finch finchRobot)
            {
                Console.CursorVisible = false;

                bool robotConnected;

                DisplayScreenHeader("Connect Finch Robot");

                Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
                DisplayContinuePrompt();

                robotConnected = finchRobot.connect();

                // TODO test connection and provide user feedback - text, lights, sounds
                while (robotConnected == false) ;
                {
                    Console.WriteLine();
                    Console.WriteLine("\tConnecting to Finch Robot...");
                }
                Console.WriteLine();
                Console.WriteLine("\tFinch Robot connected successfully");
                finchRobot.setLED(55, 55, 55);
                finchRobot.noteOn(880);
                DisplayMenuPrompt("Main Menu");

                //
                // reset finch robot
                //
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();

                return robotConnected;
            }

            #endregion

            #region USER INTERFACE

            /// <summary>
            /// *****************************************************************
            /// *                     Welcome Screen                            *
            /// *****************************************************************
            /// </summary>
            static void DisplayWelcomeScreen()
            {
                Console.CursorVisible = false;

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\t\tFinch Control");
                Console.WriteLine();

                DisplayContinuePrompt();
            }

            /// <summary>
            /// *****************************************************************
            /// *                     Closing Screen                            *
            /// *****************************************************************
            /// </summary>
            static void DisplayClosingScreen()
            {
                Console.CursorVisible = false;

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\t\tThank you for using Finch Control!");
                Console.WriteLine();

                DisplayContinuePrompt();
            }

            /// <summary>
            /// display continue prompt
            /// </summary>
            static void DisplayContinuePrompt()
            {
                Console.WriteLine();
                Console.WriteLine("\tPress any key to continue.");
                Console.ReadKey();
            }

            /// <summary>
            /// display menu prompt
            /// </summary>
            static void DisplayMenuPrompt(string menuName)
            {
                Console.WriteLine();
                Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
                Console.ReadKey();
            }

            /// <summary>
            /// display screen header
            /// </summary>
            static void DisplayScreenHeader(string headerText)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\t\t" + headerText);
                Console.WriteLine();
            }

            #endregion
        }
    }
