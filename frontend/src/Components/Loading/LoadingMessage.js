import React from 'react';
import styles from './LoadingMessage.css';

const messages = [
  'Downloading more RAM...',
  'Now in Technicolor...',
  'Previously on Radarr...',
  'Locating the required gigapixels to render...',
  'Spinning up the hamster wheel...',
  'At least you\'re not on hold...',
  'Be kind, rewind...',
  'RE-calibrating the internet...',
  'Loading Battlestation...',
  'Reticulating splines...',
  'Generating witty dialog...',
  'Swapping time and space...',
  'Spinning violently around the y-axis...',
  'Tokenizing real life...',
  'Filtering morale...',
  '640K ought to be enough for anybody...',
  'The architects are still drafting...',
  'The bits are breeding...',
  'We\'re building the buildings as fast as we can...',
  'Pay no attention to the man behind the curtain...',
  'Please wait while the little elves draw your map...',
  'Would you like fries with that?',
  'Checking the gravitational constant in your locale...',
  'You\'re not in Kansas any more...',
  'The server is powered by a lemon and two electrodes...',
  'We\'re testing your patience...',
  'As if you had any other choice...',
  'Follow the white rabbit...',
  'While the satellite moves into position...',
  'The bits are flowing slowly today...',
  'It\'s still faster than you could draw it...',
  'I should have had a V8 this morning...',
  'My other loading screen is much faster...',
  'Testing on Timmy... We\'re going to need another Timmy...',
  'Are we there yet?',
  'It\'s not you. It\'s me...',
  'Counting backwards from Infinity...',
  'Don\'t panic...',
  'Creating time-loop inversion field...',
  'Spinning the wheel of fortune...',
  'Loading the enchanted bunny...',
  'Computing chance of success...',
  'Looking for exact change...',
  'All your web browser are belong to us...',
  'I feel like im supposed to be loading something...',
  'Adjusting flux capacitor...',
  'I swear it\'s almost done...',
  'Let\'s take a mindfulness minute...',
  'Keeping all the 1\'s and removing all the 0\'s...',
  'Cleaning off the cobwebs...',
  'Granting wishes...',
  'Spinning the hamster…...',
  '99 bottles of beer on the wall...',
  'Computing the secret to life, the universe, and everything...',
  'Constructing additional pylons...',
  'Dividing by zero...',
  'Entangling superstrings...',
  'Twiddling thumbs...',
  'Let\'s hope it\'s worth the wait...',
  'Ordering 1s and 0s...',
  'Initializing the initializer...',
  'Optimizing the optimizer...',
  'Pushing pixels...',
  'Updating Updater...',
  'Downloading Downloader...',
  'Debugging Debugger...',
  'Patience! This is difficult, you know...',
  'Discovering new ways of making you wait...',
  'Your time is very important to us. Please wait while we ignore you...'
];

let message = null;

function LoadingMessage() {
  if (!message) {
    const index = Math.floor(Math.random() * messages.length);
    message = messages[index];
  }

  return (
    <div className={styles.loadingMessage}>
      {message}
    </div>
  );
}

export default LoadingMessage;
