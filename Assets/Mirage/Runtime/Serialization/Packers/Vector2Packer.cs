/*
MIT License

Copyright (c) 2021 James Frowen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using UnityEngine;

namespace Mirage.Serialization
{
    public sealed class Vector2Packer
    {
        private readonly FloatPacker _xPacker;
        private readonly FloatPacker _yPacker;

        public Vector2Packer(float xMax, float yMax, int xBitCount, int yBitCount)
        {
            _xPacker = new FloatPacker(xMax, xBitCount);
            _yPacker = new FloatPacker(yMax, yBitCount);
        }
        public Vector2Packer(float xMax, float yMax, float xPrecision, float yPrecision)
        {
            _xPacker = new FloatPacker(xMax, xPrecision);
            _yPacker = new FloatPacker(yMax, yPrecision);
        }
        public Vector2Packer(Vector2 max, Vector2 precision)
        {
            _xPacker = new FloatPacker(max.x, precision.x);
            _yPacker = new FloatPacker(max.y, precision.y);
        }

        public void Pack(NetworkWriter writer, Vector2 value)
        {
            _xPacker.Pack(writer, value.x);
            _yPacker.Pack(writer, value.y);
        }

        public Vector2 Unpack(NetworkReader reader)
        {
            Vector2 value = default;
            value.x = _xPacker.Unpack(reader);
            value.y = _yPacker.Unpack(reader);
            return value;
        }
    }
}
