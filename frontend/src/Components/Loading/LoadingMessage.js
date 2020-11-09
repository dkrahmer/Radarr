import React from 'react';
import styles from './LoadingMessage.css';

const messages = [
  "Downloading more RAM...",
  "Now in Technicolor...",
  "Previously on Radarr...",
  "Bleep Bloop...",
  "Locating the required gigapixels to render...",
  "Spinning up the hamster wheel...",
  "At least you're not on hold...",
  "Be kind, rewind...",
  "RE-calibrating the internet...",
  "Loading Battlestation...",
  "Reticulating splines...",
  "Generating witty dialog...",
  "Swapping time and space...",
  "Spinning violently around the y-axis...",
  "Tokenizing real life...",
  "Bending the spoon...",
  "Filtering morale...",
  "640K ought to be enough for anybody...",
  "The architects are still drafting...",
  "The bits are breeding...",
  "We're building the buildings as fast as we can...",
  "Pay no attention to the man behind the curtain...",
  "Please wait while the little elves draw your map...",
  "Don't worry - a few bits tried to escape, but we caught them...",
  "Would you like fries with that?",
  "Checking the gravitational constant in your locale...",
  "Go ahead -- hold your breath...",
  "You're not in Kansas any more...",
  "The server is powered by a lemon and two electrodes...",
  "We're testing your patience...",
  "As if you had any other choice...",
  "Follow the white rabbit...",
  "While the satellite moves into position...",
  "keep calm and npm install...",
  "The bits are flowing slowly today...",
  "It's still faster than you could draw it...",
  "The last time I tried this the monkey didn't survive. Let's hope it works better this time...",
  "I should have had a V8 this morning...",
  "My other loading screen is much faster...",
  "Testing on Timmy... We're going to need another Timmy...",
  "Reconfoobling energymotron...",
  "Insert quarter...",
  "Are we there yet?",
  "Just count to 10...",
  "It's not you. It's me...",
  "Counting backwards from Infinity...",
  "Don't panic...",
  "Embiggening Prototypes...",
  "Warning: Don't set yourself on fire...",
  "We're making you a cookie...",
  "Creating time-loop inversion field...",
  "Spinning the wheel of fortune...",
  "Loading the enchanted bunny...",
  "Computing chance of success...",
  "Looking for exact change...",
  "All your web browser are belong to us...",
  "All I really need is a kilobit...",
  "I feel like im supposed to be loading something...",
  "What do you call 8 Hobbits? A Hobbyte...",
  "Adjusting flux capacitor...",
  "Please wait until the sloth starts moving...",
  "Don't break your screen yet!",
  "I swear it's almost done...",
  "Let's take a mindfulness minute...",
  "Unicorns are at the end of this road, I promise...",
  "Listening for the sound of one hand clapping...",
  "Keeping all the 1's and removing all the 0's...",
  "Cleaning off the cobwebs...",
  "Making sure all the i's have dots...",
  "We need more dilithium crystals...",
  "Where did all the internets go...",
  "Connecting Neurotoxin Storage Tank...",
  "Granting wishes...",
  "Spinning the hamster…...",
  "99 bottles of beer on the wall...",
  "Load it and they will come...",
  "Convincing AI not to turn evil...",
  "There is no spoon. Because we are not done loading it...",
  "Computing the secret to life, the universe, and everything...",
  "Constructing additional pylons...",
  "Roping some seaturtles...",
  "Locating Jebediah Kerman...",
  "Dividing by zero...",
  "Cracking military-grade encryption...",
  "Simulating traveling salesman...",
  "Proving P=NP...",
  "Entangling superstrings...",
  "Twiddling thumbs...",
  "Searching for plot device...",
  "Trying to sort in O(n)...",
  "Laughing at your pictures-i mean, loading...",
  "Sending data to NS-i mean, our servers...",
  "Looking for sense of humour, please hold on...",
  "Let's hope it's worth the wait...",
  "Ordering 1s and 0s...",
  "Updating dependencies...",
  "Whatever you do, don't look behind you...",
  "Please wait... Consulting the manual...",
  "Loading funny message...",
  "Mining some bitcoins...",
  "Updating to Windows Vista...",
  "Initializing the initializer...",
  "Optimizing the optimizer...",
  "Pushing pixels...",
  "Building a wall...",
  "Updating Updater...",
  "Downloading Downloader...",
  "Debugging Debugger...",
  "Running with scissors...",
  "Patience! This is difficult, you know...",
  "Discovering new ways of making you wait...",
  "Your time is very important to us. Please wait while we ignore you..."
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
