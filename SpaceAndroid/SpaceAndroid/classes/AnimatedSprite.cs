using System;
using System.Collections.Generic;

namespace SpaceAndroid {
    public class AnimatedSprite {

        List<AnimatedSpriteFrame> frames;
        public TimeSpan duration;
        public bool loop;
        public int once = 0;

        public AnimatedSprite(TimeSpan t) {
            frames = new List<AnimatedSpriteFrame>();
            duration = t;
        }

        public void AddFrame (AnimatedSpriteFrame f) {
            frames.Add(f);
        }

        public sprite SpriteAtTime(TimeSpan t) {
            AnimatedSpriteFrame frame;
            //TODO: popravi non looping frame
            if (once < 9) {
                if (loop) {
                    double loops = Math.Floor(t / duration);
                    t -= loops * duration;
                }

                if (t >= duration) {
                    return null;
                }

                for (int i = 0; i < frames.Count - 1; i++) {
                    AnimatedSpriteFrame nextFrame = frames[i + 1];


                    if (nextFrame.start > t) {
                        frame = frames[i];
                        once++;
                        return frame.frame;
                    }
                }

                frame = frames[frames.Count - 1];
                return frame.frame;
            }
            once = 0;
            return null;
        }

    }
}

