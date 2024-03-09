using ExaminationBLL.ModelVM.GenerateVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.Feature.Interface
{
    public interface IGenerateExamRepo
    {
        void Generate(GenerateExam generateExam);

        GenerateExam Get(int id);
    }
}
