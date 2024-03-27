using UnityEngine;

namespace Cells
{
    public class CellParticles
    {
        private ParticleSystem _correctAnswerChosenParticles;

        public CellParticles(ParticleSystem correctAnswerChosenParticles)
        {
            _correctAnswerChosenParticles = correctAnswerChosenParticles;
        }

        public void PlayCorrectParticles(CellView cellView)
        {
            var copy = Object.Instantiate(_correctAnswerChosenParticles);
            copy.transform.position = cellView.transform.position;
            copy.PlayWithDestroy();
        }
    }
}