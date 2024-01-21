using Entities;
using Repositories;
using Services;

var logger = new SimpleLoggerService();

var app = new App(new UserService(new UserRepository(), logger, new NotificationService(logger)), new ToyService(new ToyRepository()));
app.Start();