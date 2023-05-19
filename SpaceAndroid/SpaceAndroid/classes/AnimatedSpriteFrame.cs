using System;
namespace SpaceAndroid {
    public class AnimatedSpriteFrame {
        public sprite frame;
        public TimeSpan start;

        public AnimatedSpriteFrame(sprite s, TimeSpan t) {
            frame = s;
            start = t;
        }
    }
}

