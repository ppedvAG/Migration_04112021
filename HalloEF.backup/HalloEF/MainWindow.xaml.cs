using Bogus;
using HalloEF.Model;
using System.Linq;
using System.Windows;
using System.Data.Entity;

namespace HalloEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        EfContext context = new EfContext();

        private void Laden(object sender, RoutedEventArgs e)
        {
            //myGrid.ItemsSource = context.Mitarbeiter.ToList();//SELECT *
            myGrid.ItemsSource = context.Mitarbeiter.Include(x => x.Abteilungen)
                                                    .Where(x => x.GebDatum.Month > 4 &&
                                                                x.Abteilungen.Any(y => y.Mitarbeiter.Count() > 12))
                                                    .OrderBy(x => x.Beruf.Length / 2)
                                                    .ThenByDescending(x => x.GebDatum.Year)
                                                    .ToList();
        }

        private void DemoDaten(object sender, RoutedEventArgs e)
        {
            var depFaker = new Faker<Abteilung>();
            depFaker.UseSeed(1);
            depFaker.RuleFor(x => x.Bezeichnung, y => y.Commerce.Department());

            var abts = depFaker.Generate(5);

            var mitFaker = new Faker<Mitarbeiter>("de");
            mitFaker.UseSeed(1);
            mitFaker.RuleFor(x => x.Name, y => y.Name.FullName());
            mitFaker.RuleFor(x => x.GebDatum, y => y.Date.Past(40));
            mitFaker.RuleFor(x => x.Beruf, y => $"{y.Name.JobDescriptor()} {y.Name.JobTitle()}");
            mitFaker.RuleFor(x => x.Abteilungen, y => y.PickRandom(abts, 2).ToHashSet());

            for (int i = 0; i < 100; i++)
            {
                var mit = mitFaker.Generate();
                context.Mitarbeiter.Add(mit);
            }

            context.SaveChanges();

        }

        private void Speichern(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void Löschen(object sender, RoutedEventArgs e)
        {
            if (myGrid.SelectedItem is Mitarbeiter m)
            {
                context.Mitarbeiter.Remove(m);
            }
        }
    }
}
