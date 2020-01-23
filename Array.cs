using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数组
{
    class Program
    {
        public static void Main(String[] args)
        {
            MyArray myArray = new MyArray(4);
            myArray.insert(0, 3);
            myArray.insert(1, 7);
            myArray.insert(2, 9);
            myArray.insert(3, 5);
            myArray.insert(1, 6);
            myArray.output();
        }
    }
    class MyArray
    {
        public int[] array;
        public int size;
        public MyArray(int capacity)
        {
            this.array = new int[capacity];
            size = 0;
        }

        public void insert(int index, int element)
        {
            if (index<0||index> size){
                throw new IndexOutOfRangeException(
                    "超出数组实际元素范围");
            }
            if (size >= array.Length)//当元素等于实例数组的长度就创建
            {
                resize();
            }
            //
            for (int i = size-1; i >=index; i--)
            {//这里会对凡是第一次插入的都不会进行运算，插入的重点
                array[i + 1] = array[i];
            }
            //
            array[index] = element;
            size++;
        }

        public int delete(int index)//删除元素，删除位置后面数组左移
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("超出数组实际元素范围");
            }
            int deletedElement = array[index];
            for (int i = index; i < size-1; i++)
            {
                array[i] = array[i + 1];
            }
            size--;
            return deletedElement;
        }

        public void output() {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        public void resize()
        {
            int[] arrayNew = new int[array.Length * 2];
            Array.Copy(array, arrayNew, array.Length);
            array = arrayNew;
        }
    }
}
