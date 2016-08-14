using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class ProjectBuilder
    {
        public async void SequenceBuilder()
        {
            var task1 = new Task(() => Builder("project 1"));
            var task2 = new Task(() => Builder("project 2"));
            var task3 = new Task(() => Builder("project 3"));
            var task4 = new Task(() => Builder("project 4"));
            var task5 = new Task(() => Builder("project 5"));
            var task6 = new Task(() => Builder("project 6"));
            var task7 = new Task(() => Builder("project 7"));
            var task8 = new Task(() => Builder("project 8"));
            var firstpair = new Task[2];
            var secondtpair = new Task[2];
            var thridpair = new Task[2];

            task8.Start();
            firstpair[0] = Task.Factory.StartNew(task7.Start);
            secondtpair[0] = firstpair[0].ContinueWith(t => task6.Start());
            thridpair[0] = secondtpair[0].ContinueWith(t => task4.Start());
            firstpair[1] = Task.Factory.StartNew(task8.Start);
            
            secondtpair[1] = Task.Factory.ContinueWhenAll(firstpair, t => task5);
            thridpair[1] = secondtpair[1];
            await secondtpair[0].ContinueWith(t => task2.Start());
            await Task.Factory.ContinueWhenAll(secondtpair, t => task3.Start());
            await Task.Factory.ContinueWhenAll(thridpair, t => task1.Start());
        }

        private void Builder(string projectName)
        {
            Console.WriteLine("started building "+projectName);
            Thread.Sleep(50);
            Console.WriteLine("Finised building " + projectName);
        }
    }
}
