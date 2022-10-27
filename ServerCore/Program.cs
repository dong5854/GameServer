using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        // 스레드는 각자 자신의 스택 메모리를 갖지만, 전역으로 선언된 변수는 모든 스레드가 공통으로 사용을 해서 동시 접근이 가능하다.
        volatile static bool _stop = false;

        static void ThreadMain()
        {
            Console.WriteLine("쓰레드 시작!");

         /* if (_stop == false)
            {
                while (true)
                {

                }
            }*/

            while (_stop == false)
            {
                //누군가가 stop 신호를 해주기를 기다린다.
            }

            Console.WriteLine("쓰레드 종료!");
        }
        static void Main(string[] args)
        {
            Task t = new Task(ThreadMain);
            t.Start();

            // 1초 동안 대기
            Thread.Sleep(1000);

            _stop = true;

            Console.WriteLine("Stop 호출");
            Console.WriteLine("종료 대기중");

            t.Wait();

            Console.WriteLine("종료 성공");
        }
    }
}
