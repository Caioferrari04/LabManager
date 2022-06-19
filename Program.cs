using LabManager.Database;
using LabManager.Models;
using LabManager.Repositories;

var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var computerRepository = new ComputerRepository(databaseConfig);
var labRepository = new LabRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

try
{
    switch (modelName)
    {
        case "Computer":
            {
                switch (modelAction)
                {
                    case "List":
                        {
                            foreach (var computer in computerRepository.GetAll())
                            {
                                Console.WriteLine($"{computer.ID}, {computer.Ram}, {computer.Processor}");
                            }
                            break;
                        }
                    case "New":
                        {
                            var id = Convert.ToInt32(args[2]);
                            var ram = args[3];
                            var processor = args[4];

                            var computer = new Computer(id: id, ram: ram, processor: processor);

                            computerRepository.Save(computer);

                            break;
                        }
                    case "Show":
                        {
                            var id = Convert.ToInt32(args[2]);

                            if (computerRepository.ExistsById(id))
                            {
                                var computer = computerRepository.GetById(id);

                                Console.WriteLine($"{computer.ID}, {computer.Ram}, {computer.Processor}");
                                break;
                            }
                            Console.WriteLine("Não existe computador com esse ID");
                            break;
                        }
                    case "Update":
                        {
                            var id = Convert.ToInt32(args[2]);

                            if (computerRepository.ExistsById(id))
                            {
                                var ram = args[3];
                                var processor = args[4];

                                var computer = new Computer(id: id, ram: ram, processor: processor);
                                computerRepository.Update(computer);

                                Console.WriteLine($"Computador de ID {id} atualizado com sucesso.");
                                break;
                            }
                            Console.WriteLine("Não existe computador com esse ID");
                            break;
                        }
                    case "Delete":
                        {
                            var id = Convert.ToInt32(args[2]);
                            if (computerRepository.ExistsById(id))
                            {
                                computerRepository.Delete(id);

                                Console.WriteLine($"Computador de ID {id} excluído com sucesso.");
                                break;
                            }
                            Console.WriteLine("Não existe computador com esse ID");
                            break;
                        }
                    default:
                        throw new ApplicationException("Operacao invalida");
                }
                break;
            }
        case "Lab":
            {
                switch (modelAction)
                {
                    case "List":
                        {
                            foreach (var lab in labRepository.GetAll())
                            {
                                Console.WriteLine($"{lab.ID}, {lab.Name}, {lab.Block}, {lab.Number}");
                            }
                            break;
                        }
                    case "New":
                        {
                            var id = Convert.ToInt32(args[2]);
                            var name = args[3];
                            var block = args[4];
                            var number = Convert.ToInt32(args[5]);

                            var lab = new Lab(id: id, name: name, block: block, number: number);

                            labRepository.Save(lab);

                            break;
                        }
                    case "Show":
                        {
                            var id = Convert.ToInt32(args[2]);
                            if (labRepository.ExistsById(id))
                            {
                                var lab = labRepository.GetById(id);

                                Console.WriteLine($"{lab.ID}, {lab.Name}, {lab.Block}, {lab.Number}");
                                break;
                            }
                            Console.WriteLine("Não existe laboratorio com esse ID");
                            break;
                        }
                    case "Update":
                        {
                            var id = Convert.ToInt32(args[2]);
                            if (labRepository.ExistsById(id))
                            {
                                var name = args[3];
                                var block = args[4];
                                var number = Convert.ToInt32(args[5]);

                                var lab = new Lab(id: id, name: name, block: block, number: number);
                                lab = labRepository.Update(lab);

                                Console.WriteLine($"{lab.ID}, {lab.Name}, {lab.Block}, {lab.Number}");
                                break;
                            }
                            Console.WriteLine("Não existe laboratorio com esse ID");
                            break;
                        }
                    case "Delete":
                        {
                            var id = Convert.ToInt32(args[2]);

                            if (labRepository.ExistsById(id))
                            {
                                labRepository.Delete(id);

                                Console.WriteLine($"Laboratório de ID {id} excluído com sucesso.");
                                break;
                            }
                            Console.WriteLine("Não existe laboratorio com esse ID");
                            break;
                        }
                    default:
                        throw new ApplicationException("Operacao invalida");
                }
                break;
            }
        default:
            throw new ApplicationException("Modelo invalido");
    }
}
catch (ApplicationException erro)
{
    Console.WriteLine(erro.Message);
}
