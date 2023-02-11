# ATS
Advanced Trigger System

Welcome to the Advanced Trigger System!

At the moment there are 2 types of triggers: one-time and multi-use.

You can create triggers with context menu GameObject>Triggers

One time event - the event attached to the trigger is called once and then the object will be destroyed.
Multi-use - the event attached to the trigger will be called every time you enter it.
If object collides with a multi-use trigger, the event will be called and the object will be deactivated. When exiting - it will turn on again.

For triggers to work, your objects must have a "Player" or "Object" tag.
Also add ATS Behaviour for it to work properly.
