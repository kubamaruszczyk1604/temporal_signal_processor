# temporal_signal_processor
Temporal Signal Processor is a 1D kernel convolution filter.
Size of the window is constant and equal to the size of the kernel. 
New data points can be added using Put() function. 
When new points are added, the signal window shifts and points that moved outside are removed (FIFO like manner).
