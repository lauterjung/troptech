using System;
using System.Collections.Generic;
using SalaReunioes.Domain;
using SalaReunioes.Domain.Exceptions;
using SalaReunioes.Infra.Data;

namespace SalaReunioes.ConsoleApp
{
    public static class ReservationActions
    {
        private static string _userInput;
        private static ReservationRepository _reservationRepository = new ReservationRepository();
        private static RoomRepository _roomRepository = new RoomRepository();
        private static EmployeeRepository _employeeRepository = new EmployeeRepository();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("========= RESERVAS =========");
            Console.WriteLine("[1] Adicionar Reserva");
            Console.WriteLine("[2] Pesquisar todas as Reservas");
            Console.WriteLine("[0] Voltar");
            Console.WriteLine("============================\n");

            AskForInput();
        }

        public static void AskForInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();

            ChooseOption();
        }

        public static void ChooseOption()
        {
            Console.Clear();
            switch (_userInput)
            {
                case "1":
                    AddReservation();
                    break;
                case "2":
                    SearchAllReservations();
                    break;
                case "0":
                    _userInput = "";
                    SystemActions.Menu();
                    break;
                default:
                    Console.WriteLine("Operação inválida. Pressione enter para continuar...");
                    break;
            }
            Console.ReadKey();

            Menu();
        }

        public static void AddReservation()
        {
            List<Reservation> futureReservations = _reservationRepository.SearchFutureReservations();
            try
            {
                System.Console.Write("Digite a sala desejada: ");
                AvailableRooms roomEnum = StringToAvailableRooms(Console.ReadLine());

                Room room = _roomRepository.searchRoomByName(roomEnum.ToString());

                System.Console.Write("Digite o ID funcionário: ");
                int employeeId = Convert.ToInt32(Console.ReadLine());
                Employee employee = _employeeRepository.SearchEmployeeById(employeeId);

                System.Console.Write("Digite a data de início (AAAA-MM-DD): ");
                string startDate = Console.ReadLine();
                System.Console.Write("Digite a hora de início (hh:mm:ss): ");
                string startTime = Console.ReadLine();
                DateTime startDateTime = Convert.ToDateTime(startDate + " " + startTime);

                System.Console.Write("Digite a data de fim (AAAA-MM-DD): ");
                string endDate = Console.ReadLine();
                System.Console.Write("Digite a hora de fim (hh:mm:ss): ");
                string endTime = Console.ReadLine();
                DateTime endDateTime = Convert.ToDateTime(endDate + " " + endTime);


                Reservation reservation = room.MakeReservation(startDateTime, endDateTime, employee, futureReservations);

                _reservationRepository.AddReservation(reservation);
                System.Console.WriteLine("Reserva cadastrada com sucesso!");
            }
            catch (RoomAlreadyBooked ex)
            {
                Console.Clear();
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine("Reservas futuras:");
                foreach (Reservation reservation in futureReservations)
                {
                    System.Console.WriteLine(reservation.ToString());
                }

            }
            catch (InvalidDateTimeException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (InexistingAvailableRoom ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (EmployeeNotFound ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            // catch (System.Exception)
            // {
            //     System.Console.WriteLine("Input inválido!");
            // }
        }

        public static void SearchAllReservations()
        {
            try
            {
                List<Reservation> reservationList = new List<Reservation>();
                reservationList = _reservationRepository.SearchAllReservations();
                Console.Clear();

                foreach (Reservation reservation in reservationList)
                {
                    System.Console.WriteLine(reservation.ToString());
                }
            }
            catch (ZeroReservationsRegistered ex)
            {
                System.Console.WriteLine(ex.Message); ;
            }
        }

        public static AvailableRooms StringToAvailableRooms(string roomStr)
        {
            AvailableRooms roomName;

            int number;
            bool isNumeric = int.TryParse(roomStr, out number);
            if (isNumeric == true && !Enum.IsDefined(typeof(AvailableRooms), number))
            {
                throw new InexistingAvailableRoom();
            }

            if (Enum.TryParse(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(roomStr.ToLower()), out roomName))
            {
                return roomName;
            }

            throw new InexistingAvailableRoom();
        }

        public static void Run()
        {
            Menu();
        }
    }
}
