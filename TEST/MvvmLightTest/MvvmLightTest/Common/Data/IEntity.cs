using System.Security.Cryptography.X509Certificates;
using GalaSoft.MvvmLight;

namespace MvvmLightTest.Common.Data
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public interface IEntity
    {
      int ID { get; }
    }
}