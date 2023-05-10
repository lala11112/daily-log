using System;

namespace CircleCollision
{
    class Point
    {
        public float x;
        public float y;

        public Point() // 원점 생성
        {
            x = 0f;
            y = 0f;
        }

        public Point(float x, float y) // 점 생성
        {
            this.x = x;
            this.y = y;
        }
        public void PrintPoint() // 점 출력
        {
            Console.WriteLine($"Point({x},{y})");
        }
    }

    class Vector
    {
        public float x;
        public float y;
        public Vector(float x, float y) // 벡터 생성
        {
            this.x = x;
            this.y = y;
        }
        public Vector Normalized() // 벡터의 정규화 
        {
            float magnitude = Mathm.SquareRoot(x * x + y * y);
            float nx = x / magnitude;
            float ny = y / magnitude;
            return new Vector(nx, ny);
        }
        public void PrintVector() // 벡터 출력
        {
            Console.WriteLine($"Vector({x},{y})");
        }
    }

    class Circle
    {
        public Point origin = new Point();
        public float radius;

        public Circle() // 랜덤한 원 생성
        {
            origin.x = Mathm.XorShiftRandom() * 10;
            origin.y = Mathm.XorShiftRandom() * 10;
            radius = Mathm.XorShiftRandom() * 5 + 1;
        }

        public Circle(float x, float y, float r) // 지정된 원 생성
        {
            origin.x = x;
            origin.y = y;
            radius = r;
        }

        public void MoveCircle(Vector mv) // 원의 이동
        {
            Console.WriteLine($"Move Vector:({mv.x.ToString("0.0")}, " +
                $"{mv.y.ToString("0.0")})");
            origin.x += mv.x;
            origin.y += mv.y;
            Console.WriteLine("[원의 이동 결과]");
            PrintCircle();
        }

        /// <summary>
        /// 다른 원과 중심점 간의 거리 계산
        /// </summary>
        /// <param name="c">다른 원"</param>
        /// <returns>다른 원과의 거리</returns>
        public float Distance(Circle c) //원과의 거리
        {
            float x = origin.x - c.origin.x;
            float y = origin.y - c.origin.y;
            return x * x + y * y;
        }

        public void PrintCircle() // 원의 출력
        {
            Console.WriteLine($"Circle({origin.x.ToString("0.0")}," +
                $" {origin.y.ToString("0.0")}) : {radius.ToString("0.0")}");
        }
    }

    /// <summary>
    ///  XorShiftRandom & SquareRoot
    /// </summary>
    public static class Mathm
    {
        private static uint x = (uint)DateTime.Now.Ticks;
        private static uint y = (uint)DateTime.Now.Ticks;
        private static uint z = (uint)DateTime.Now.Ticks;
        private static uint w = (uint)DateTime.Now.Ticks;

        public static float XorShiftRandom()
        {
            uint t = x ^ (x << 11);
            x = y; y = z; z = w;
            w = (w ^ (w >> 19)) ^ (t ^ (t >> 8));
            return w / (float)uint.MaxValue;
        }

        public static float SquareRoot(float d) //  = Math.sqrt()
        {
            float x = d;
            float y = 1;
            while (x - y > 0.001f)
            {
                x = (x + y) / 2;
                y = d / x;
            }
            return x;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle();
            Circle c2 = new Circle();
            //Circle c1 = new Circle(3.0f, 6.0f, 5.0f); // 1단계 : 원 생성
            //Circle c2 = new Circle(4.0f, 4.0f, 5.0f);

            c1.PrintCircle(); // 원 출력
            c2.PrintCircle();

            Vector mv = CheckCollision(c1, c2); // 2단계 : 충돌체크
            c2.MoveCircle(mv);          // 3단계 : 충돌시 이동  
        }

        private static Vector CheckCollision(Circle c1, Circle c2)  // 충돌 검사
        {
            float dSqaure = c1.Distance(c2);
            float rSum = c1.radius + c2.radius;

            if (dSqaure < rSum * rSum)
            {
                Console.WriteLine("[충돌 발생]");
                float magnitude = rSum - Mathm.SquareRoot(dSqaure); // 이동 크기               

                float x = c2.origin.x - c1.origin.x; // c2.origin - c1.origin 가능하게 확장
                float y = c2.origin.y - c1.origin.y;
                Vector moveDir = new Vector(x, y).Normalized(); // 이동 방향
                //return moveDir * magnitude;                                                                 
                return new Vector(moveDir.x * magnitude, moveDir.y * magnitude); // 이동 벡터                     
            }
            else
            {
                return new Vector(0, 0);
            }
        }
    }
}
